using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Domain.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Создаёт access-токен.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        string CreateToken(Patient user, List<IdentityRole<long>> role);
    }
}
