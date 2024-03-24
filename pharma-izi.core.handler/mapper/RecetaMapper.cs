using AutoMapper;
using pharma_izi.core.handler.mediator.doctor.getAllRecetas;
using pharma_izi.core.handler.mediator.doctor.login;
using pharma_izi.core.infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mapper
{
    public class RecetaMapper : Profile
    {
        public RecetaMapper()
        {
            CreateMap<Receta, GetAllRecetasDoctorOut.RecetasByDoctor>()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForPath(dest => dest.fecha_registro, opt => opt.MapFrom(src => src.FechaRegistro))
                .ForPath(dest => dest.emailCliente, opt => opt.MapFrom(src => src.IdClienteNavigation.Email))
                .ForPath(dest => dest.celularCliente, opt => opt.MapFrom(src => src.IdClienteNavigation.Celular))
                .ForPath(dest => dest.nombreCliente, opt => opt.MapFrom(src => src.IdClienteNavigation.Nombre))
                .ForPath(dest => dest.apellidoCliente, opt => opt.MapFrom(src => src.IdClienteNavigation.Apellido));
        }
    }
}
