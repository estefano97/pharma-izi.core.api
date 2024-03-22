using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pharma_izi.core.infrastructure.Database;
using QRCoder;
using System;
using System.Drawing;

namespace pharma_izi.core.handler.mediator.receta.crearCodigoQR
{
    internal class CrearCodigoQrRecetaHandler : IRequestHandler<CrearCodigoQrRecetaQuery, CrearCodigoQrRecetaOut>
    {
        private readonly IConfiguration _configuration;
        private readonly PharmaIziContext _context;
        public CrearCodigoQrRecetaHandler(IConfiguration configuration, PharmaIziContext context)
        {
            _configuration = configuration;
            _context = context;
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
                Bitmap qrCodeImage = qrCode.GetGraphic(2);

                // Convertir la imagen en formato base64
                string base64Image;
                using (MemoryStream ms = new MemoryStream())
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes);
                }

                var addedQrCode = await _context.CodigosQrs.Where(el => el.Id == request.idQrCode).FirstOrDefaultAsync();

                if (addedQrCode != null)
                {
                    addedQrCode.Valor = base64Image;
                }
                else
                {
                    await _context.CodigosQrs.AddAsync(new CodigosQr
                    {
                        Id = Guid.NewGuid(),
                        Valor = base64Image
                    });
                }

                await _context.SaveChangesAsync();
                 
                return new CrearCodigoQrRecetaOut { QrCode = base64Image };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
