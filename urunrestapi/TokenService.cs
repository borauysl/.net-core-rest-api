using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace urunrestapi
{
    public class TokenService
    {
        private readonly JwtAyarlari _jwtAyarlari;

        public TokenService(IOptions<JwtAyarlari> jwtAyarlari)
        {
            _jwtAyarlari = jwtAyarlari.Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtAyarlari.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Rol) 
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _jwtAyarlari.Issuer,
                Audience = _jwtAyarlari.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}