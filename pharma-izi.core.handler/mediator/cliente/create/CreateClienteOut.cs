using pharma_izi.core.infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.cliente.create
{
    public class CreateClienteOut
    {
        public Guid idUsuario { get; set; }
        public Cliente cliente { get; set; }
    }
}
