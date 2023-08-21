using System.IdentityModel.Tokens.Jwt;
using MedicineProject.Extensions;
using MedicineProject.Models;
using Microsoft.AspNetCore.Identity;


namespace MedicineProject.Services
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
