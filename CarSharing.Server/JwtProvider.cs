using CarSharing.Server.Interface;
using CarSharing.Server.Models.JWT;
using CarSharing.Server.Models.UserModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarSharing.Server
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }


        public string GeneratToken(User user)
        {
            Claim[] calims = [new("userId", user.Id.ToString())];

            var signing = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                   claims :calims,
                   signingCredentials : signing,
                   expires: DateTime.UtcNow.AddHours(_options.ExpitesHours));
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }

}
