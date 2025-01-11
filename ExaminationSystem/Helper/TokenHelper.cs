using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ExaminationSystem.Data;
using System.Text;
using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Helper
{
    public class TokenHelper
    {
        public static string GenerateToken(int userID , Role role)
        {
            var key = Encoding.UTF8.GetBytes(Constants.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier , userID.ToString()),
                    new Claim(ClaimTypes.Role , ((int)role).ToString())
                }),
                Issuer = Constants.JWTIssuer,
                Audience = Constants.JWTAudience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(2),
            };

            var token =  tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
