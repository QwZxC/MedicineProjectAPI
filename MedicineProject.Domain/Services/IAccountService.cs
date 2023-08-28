using MedicineProject.Domain.DTOs.Identity;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicineProject.Domain.Services
{
    public interface IAccountService
    {
        Task<Patient?> FindUserByEmailAsync(string email);

        Task<bool> CheckPasswordAsync(Patient user, string password);

        Task<Patient?> FindByEmailInDbAsync(string email);

        Task<List<long>> FindRoleIdsAsync(long userId);

        Task<List<IdentityRole<long>>> FindRolesAsync(List<long> roleIds);

        string GenerateRefreshToken();

        DateTime GetRefreshTokenExpiryTime();

        Task SaveChangedAsync();

        Task<IdentityRole<long>> GetRoleByNameAsync(string name);

        Patient CreateUser(RegisterRequest request);

        Task<IdentityResult> GetResultAsync(Patient user, string password);

        Task LinkUserRole(Patient user, string role);

        Task<Patient> FindUserByNameAsync(string name);

        Task UpdateUserAsync(Patient user);

        Task RevokeAllAsync();

        ClaimsPrincipal GetPrincipal(string accessToken);

        JwtSecurityToken CreateToken(ClaimsPrincipal principal);

        void TrimProperties<T>(T request);
    }
}
