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

            var managedUser = await userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user is null)
            {
                return Unauthorized();
            }

            var roleIds = await context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var roles = context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = tokenService.CreateToken(user, roles);
            user.RefreshToken = configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            await context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = accessToken,
                RefreshToken = user.RefreshToken
            });
        }


        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(request);
            } 

            var user = new User
            {
                Name = request.FirstName,
                Surname = request.LastName,
                Patronymic = request.MiddleName,
                Email = request.Email,
                UserName = request.Email,
            };
            var result = await userManager.CreateAsync(user, request.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            if (!result.Succeeded) 
            {
                return BadRequest(request);
            } 

            var findUser = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (findUser == null) 
            {
                NotFound($"User {request.Email} not found");
            } 

            await userManager.AddToRoleAsync(findUser, request.Role);

            return await Authenticate(new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;
            ClaimsPrincipal? principal = configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            string? username = principal.Identity!.Name;
            User? user = await userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return BadRequest("Invalid access token or refresh token");
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
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }

            return Ok();
        }

    }
}
