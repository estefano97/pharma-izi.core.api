using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.receta.crearCodigoQR
{
    public class CrearCodigoQrRecetaQuery : IRequest<CrearCodigoQrRecetaOut>
    {
        public Guid idReceta { get; set; }
        public Guid idQrCode { get; set; }
    }
}
