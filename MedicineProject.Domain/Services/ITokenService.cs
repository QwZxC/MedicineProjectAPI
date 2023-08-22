using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Domain.Services
{
    public interface ITokenService
    {
        string CreateToken(Patient user, List<IdentityRole<long>> role);
    }
}
