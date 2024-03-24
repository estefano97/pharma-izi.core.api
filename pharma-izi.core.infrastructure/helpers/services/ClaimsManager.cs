using Microsoft.Extensions.Configuration;
using pharma_izi.core.infrastructure.helpers.consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.infrastructure.helpers.services
{
    internal class ClaimsManager : IClaimsManager
    {
        private readonly JwtSettings _jwtSettings;

        public ClaimsManager(IConfiguration configuration)
        {
            _jwtSettings = new JwtSettings(configuration);
        }

        public string EncriptarClaim(string texto)
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

                    using (var memoriaEncriptada = new MemoryStream())
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

        public string DesencriptarClaim(string textoEncriptado)
        {
            try
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

                    using (var memoriaDesencriptada = new MemoryStream())
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
            catch( Exception ex)
            {
                throw ex;
            }
        }
    }
}
