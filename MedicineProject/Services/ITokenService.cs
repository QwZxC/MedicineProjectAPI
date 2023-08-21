using MedicineProject.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Services
{
    public interface ITokenService
    {
        string CreateToken(Patient user, List<IdentityRole<long>> role);
    }
}
