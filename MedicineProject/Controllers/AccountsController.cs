using MedicineProject.Context;
using MedicineProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicineProject.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineProject.Extensions;
using MedicineProject.DTOs.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationContext context;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AccountsController(UserManager<User> userManager, ApplicationContext context, ITokenService tokenService, 
                                  IConfiguration configuration)
        {
            this.userManager = userManager;
            this.context = context;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User? managedUser = await userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
            {
                return BadRequest("Нет пользователя с данной почтой");
            }

            bool isPasswordValid = await userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Не верный пароль");
            }

            User? user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user is null)
            {
                return Unauthorized();
            }

            List<long> roleIds = await context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            List<IdentityRole<long>> roles = context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            string accessToken = tokenService.CreateToken(user, roles);
            user.RefreshToken = configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            await context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = accessToken,
                RefreshToken = user.RefreshToken,
                Role = request.Role
            });
        }


        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(request);
            }

            IdentityRole<long> role = await context.Roles.FirstOrDefaultAsync(role => request.Role == role.Name);

            if (role == null)
            {
                return BadRequest("Неверная роль");
            }

            User user = new User
            {
                Name = request.FirstName,
                Surname = request.LastName,
                Patronymic = request.MiddleName,
                Email = request.Email,
                UserName = request.Email,
            };
            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            if (!result.Succeeded) 
            {
                StringBuilder errors = new StringBuilder();
                result.Errors.ToList().ForEach(error => errors.AppendLine(error.Description.ToString()));
                return BadRequest(errors.ToString());
            } 

            User? findUser = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (findUser == null) 
            {
                NotFound($"Пользователь {request.Email} не найден");
            } 

            await userManager.AddToRoleAsync(findUser, request.Role);

            return await Authenticate(new AuthRequest
            {
                Email = request.Email,
                Password = request.Password,
                Role = request.Role
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Не правильный токен");
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;
            ClaimsPrincipal? principal = configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return BadRequest("неверный токен доступа или обновления");
            }

            string? username = principal.Identity!.Name;
            User? user = await userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime >= DateTime.UtcNow)
            {
                return BadRequest("неверный токен доступа или обновления");
            }

            JwtSecurityToken newAccessToken = configuration.CreateToken(principal.Claims.ToList());
            string? newRefreshToken = configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            User? user = await userManager.FindByNameAsync(username);
            if (user == null) 
            {
                return NotFound("Invalid user name");
            }

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            List<User> users = userManager.Users.ToList();
            foreach (User user in users)
            {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }

            return Ok();
        }

    }
}
