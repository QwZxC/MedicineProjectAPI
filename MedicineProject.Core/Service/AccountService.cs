﻿using MedicineProject.Domain.DTOs.Identity;
using MedicineProject.Domain.Extensions;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Repositories;
using MedicineProject.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicineProject.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Patient> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMobileAndWebRepository _repository;

        public AccountService(UserManager<Patient> userManager, IMobileAndWebRepository repository, 
                              IConfiguration configuration) 
        {
            _userManager = userManager;
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<bool> CheckPasswordAsync(Patient user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public Patient CreateUser(RegisterRequest request)
        {
            return new Patient
            {
                Name = request.FirstName,
                Surname = request.LastName,
                Patronymic = request.MiddleName,
                Email = request.Email,
                UserName = request.Email,
            };
        }

        public async Task<Patient?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Patient?> FindByEmailInDbAsync(string email)
        {
            return await _repository.FindUserByEmailAsync(email);
        }

        public async Task<List<long>> FindRoleIdsAsync(long userId)
        {
            return await _repository.FindRoleIdsAsync(userId);
        }

        public async Task<List<IdentityRole<long>>> FindRolesAsync(List<long> roleIds)
        {
            return await _repository.FindRolesAsync(roleIds);
        }

        public string GenerateRefreshToken()
        {
            return _configuration.GenerateRefreshToken();
        }

        public DateTime GetRefreshTokenExpiryTime()
        {
            return DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());
        }

        public async Task<IdentityResult> GetResultAsync(Patient user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityRole<long>> GetRoleByNameAsync(string name)
        {
            return await _repository.FindRoleByNameAsync(name);
        }

        public async Task SaveChangedAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public async Task LinkUserRole(Patient user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<Patient> FindUserByNameAsync(string name)
        {
           return await _userManager.FindByNameAsync(name);
        }

        public async Task UpdateUserAsync(Patient user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task RevokeAllAsync()
        {
            List<Patient> users = _userManager.Users.ToList();
            foreach (Patient user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }
        }

        public ClaimsPrincipal GetPrincipal(string accessToken)
        {
            return _configuration.GetPrincipalFromExpiredToken(accessToken);
        }

        public JwtSecurityToken CreateToken(ClaimsPrincipal principal)
        {
            return _configuration.CreateToken(principal.Claims.ToList());
        }
    }
}
