using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.infrastructure.helpers
{
    internal class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = new JwtSettings(_configuration);

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
                    new Claim("id", EncriptarClaim(idUser.ToString())),
                    new Claim("idTemplateReceta", EncriptarClaim(idTempateReceta.ToString())),
                    new Claim("email", EncriptarClaim(email)),
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private string EncriptarClaim(string texto)
        {
            try
            {
                byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                byte[] claveBytes = Encoding.UTF8.GetBytes(_jwtSettings.ClaimsKey);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = claveBytes;
                    aesAlg.Mode = CipherMode.ECB;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encriptador = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    byte[] textoEncriptado;

                    using (var memoriaEncriptada = new System.IO.MemoryStream())
                    {
                        using (var flujoEncriptado = new CryptoStream(memoriaEncriptada, encriptador, CryptoStreamMode.Write))
                        {
                            flujoEncriptado.Write(textoBytes, 0, textoBytes.Length);
                            flujoEncriptado.FlushFinalBlock();
                            textoEncriptado = memoriaEncriptada.ToArray();
                        }
                    }

                    return Convert.ToBase64String(textoEncriptado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DesencriptarTexto(string textoEncriptado)
        {
            byte[] textoEncriptadoBytes = Convert.FromBase64String(textoEncriptado);
            byte[] claveBytes = Encoding.UTF8.GetBytes(_jwtSettings.ClaimsKey);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = claveBytes;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform desencriptador = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] textoDesencriptadoBytes;

                using (var memoriaDesencriptada = new System.IO.MemoryStream())
                {
                    using (var flujoDesencriptado = new CryptoStream(memoriaDesencriptada, desencriptador, CryptoStreamMode.Write))
                    {
                        flujoDesencriptado.Write(textoEncriptadoBytes, 0, textoEncriptadoBytes.Length);
                        flujoDesencriptado.FlushFinalBlock();
                        textoDesencriptadoBytes = memoriaDesencriptada.ToArray();
                    }
                }

                return Encoding.UTF8.GetString(textoDesencriptadoBytes);
            }
        }
    }
}
