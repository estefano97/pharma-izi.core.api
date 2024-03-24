using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.infrastructure.helpers.consts
{
    internal class JwtSettings
    {
        public JwtSettings(IConfiguration configuration)
        {
            Key = configuration["Jwt:Key"] ?? throw new DirectoryNotFoundException();
            Issuer = configuration["Jwt:Issuer"] ?? throw new DirectoryNotFoundException();
            Audience = configuration["Jwt:Audience"] ?? throw new DirectoryNotFoundException();
            Subject = configuration["Jwt:Subject"] ?? throw new DirectoryNotFoundException();
            ClaimsKey = configuration["Jwt:ClaimsKey"] ?? throw new DirectoryNotFoundException();
        }

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
        public string ClaimsKey { get; set; }
    }
}
