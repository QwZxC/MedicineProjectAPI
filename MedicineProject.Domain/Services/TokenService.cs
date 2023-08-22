using System.IdentityModel.Tokens.Jwt;
using MedicineProject.Domain.Extensions;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace MedicineProject.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateToken(Patient user, List<IdentityRole<long>> roles)
        {
            var token = user
                .CreateClaims(roles)
                .CreateJwtToken(configuration);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
