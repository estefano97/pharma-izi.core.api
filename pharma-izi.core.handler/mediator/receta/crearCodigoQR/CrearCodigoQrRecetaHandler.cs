using MediatR;
using Microsoft.Extensions.Configuration;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace pharma_izi.core.handler.mediator.receta.crearCodigoQR
{
    internal class CrearCodigoQrRecetaHandler : IRequestHandler<CrearCodigoQrRecetaQuery, CrearCodigoQrRecetaOut>
    {
        private readonly IConfiguration _configuration;
        public CrearCodigoQrRecetaHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CrearCodigoQrRecetaOut> Handle(CrearCodigoQrRecetaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string urlToCreateQRCode = _configuration["Urls:urlWebsite"] + request.idReceta.ToString();

                // Crear el generador de código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlToCreateQRCode, QRCodeGenerator.ECCLevel.L);
                QRCode qrCode = new QRCode(qrCodeData);

                // Obtener la imagen del código QR como bitmap
                Bitmap qrCodeImage = qrCode.GetGraphic(5);

                // Convertir la imagen en formato base64
                string base64Image;
                using (MemoryStream ms = new MemoryStream())
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes);
                }

                return new CrearCodigoQrRecetaOut { QrCode = base64Image };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
