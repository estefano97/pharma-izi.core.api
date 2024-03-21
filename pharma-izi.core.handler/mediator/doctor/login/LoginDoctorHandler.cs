using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pharma_izi.core.infrastructure.Database;
using pharma_izi.core.infrastructure.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.doctor.login
{
    internal class LoginDoctorHandler : IRequestHandler<LoginDoctorQuery, LoginDoctorOut>
    {

        private readonly PharmaIziContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginDoctorHandler(PharmaIziContext context, IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _context = context;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginDoctorOut> Handle(LoginDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctorInformation = await _context.Doctores.Where(el => el.Identificacion == request.identificacion && el.Password == request.password).FirstOrDefaultAsync();
                
                if(doctorInformation == null) return new LoginDoctorOut() { IsSuccess = false};

                return new LoginDoctorOut {
                    IsSuccess = true,
                    tokenUsuario = _tokenGenerator.GenerateJsonWebTokenDoctor(doctorInformation.Id, doctorInformation.IdTemplateReceta, doctorInformation.Email),
                    informacionDoctor = _mapper.Map<LoginDoctorOut.LoginDoctorInformation>(doctorInformation)
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
