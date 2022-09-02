using Application.Common.Interface.Authentication;
using Application.Common.Interface.Services;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerators
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private JwtSettings jwtSettings { get; }

        public JwtTokenGenerator(IDateTimeProvider _dateTimeProvider, IOptions<JwtSettings> _jwtOptions)
        {
            dateTimeProvider = _dateTimeProvider;
            jwtSettings = _jwtOptions.Value;
        }

        string IJwtTokenGenerators.GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim( ClaimTypes.Name, user.FirstName),
            new Claim( ClaimTypes.Role, user.LastName),
            new Claim( JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim( JwtRegisteredClaimNames.Name,  user.FirstName),
            new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issueser,
                audience: jwtSettings.Audience,
                expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials

                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}