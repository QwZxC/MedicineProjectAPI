using MedicineProject.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, List<IdentityRole<long>> role);
    }
}
