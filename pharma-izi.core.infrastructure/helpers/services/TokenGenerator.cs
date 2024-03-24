using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pharma_izi.core.infrastructure.helpers.consts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.infrastructure.helpers.services
{
    internal class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        private readonly IClaimsManager _claimsManager;

        public TokenGenerator(IConfiguration configuration, IClaimsManager claimsManager)
        {
            _configuration = configuration;
            _jwtSettings = new JwtSettings(_configuration);
            _claimsManager = claimsManager;
        }


        public string GenerateJsonWebTokenDoctor(Guid idUser, Guid idTempateReceta, string email)
        {

            try
            {
                var claims = new[]
           {
                    new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Role, AuthenticationRoles.Doctor),
                    new Claim(TokenClaims.id, _claimsManager.EncriptarClaim(idUser.ToString())),
                    new Claim(TokenClaims.idTemplateReceta, _claimsManager.EncriptarClaim(idTempateReceta.ToString())),
                    new Claim(TokenClaims.email, _claimsManager.EncriptarClaim(email)),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var key1 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.ClaimsKey));
                var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: null, audience: null,
                    claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: singIn
                 );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
