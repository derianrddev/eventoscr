using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;

namespace BZPAY_BE.Common.Profiles
{
    public class ImprimirEntradaProfile: Profile
    {
        public ImprimirEntradaProfile()
        {
            ImprimirEntradaMapper(CreateMap<ImprimirEntrada, ImprimirEntradaDo>());
        }

        private void ImprimirEntradaMapper(IMappingExpression<ImprimirEntrada, ImprimirEntradaDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cantidad, act => act.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.FechaReserva, act => act.MapFrom(src => src.FechaReserva))
                .ForMember(dest => dest.FechaPago, act => act.MapFrom(src => src.FechaPago))
                .ForMember(dest => dest.TipoAsiento, act => act.MapFrom(src => src.TipoAsiento))
                .ForMember(dest => dest.Precio, act => act.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Total, act => act.MapFrom(src => src.Total))
                .ForMember(dest => dest.Evento, act => act.MapFrom(src => src.Evento))
                .ForMember(dest => dest.Escenario, act => act.MapFrom(src => src.Escenario))
                .ForMember(dest => dest.IdCliente, act => act.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName));
        }

    }
}
