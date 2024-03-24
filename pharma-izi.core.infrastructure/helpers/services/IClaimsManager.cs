using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.infrastructure.helpers.services
{
    public interface IClaimsManager
    {
        public string EncriptarClaim(string texto);
        public string DesencriptarClaim(string textoEncriptado);
    }
}
