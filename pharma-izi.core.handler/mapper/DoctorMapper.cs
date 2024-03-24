using AutoMapper;
using pharma_izi.core.handler.mediator.doctor.login;
using pharma_izi.core.infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mapper
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<Doctore, LoginDoctorOut.LoginDoctorInformation>();
        }
    }
}
