using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;

namespace BZPAY_BE.Common.Profiles
{
    public class CompraProfile: Profile
    {
        public CompraProfile()
        {
            CompraMapper(CreateMap<Compra, CompraDo>());
        }

        private void CompraMapper(IMappingExpression<Compra, CompraDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cantidad, act => act.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.FechaReserva, act => act.MapFrom(src => src.FechaReserva))
                .ForMember(dest => dest.FechaPago, act => act.MapFrom(src => src.FechaPago))
                .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.UpdatedBy, act => act.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Active, act => act.MapFrom(src => src.Active))
                .ForMember(dest => dest.IdCliente, act => act.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdEntrada, act => act.MapFrom(src => src.IdEntrada));
        }

    }
}
