using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models.Entities;

namespace BZPAY_BE.Common.Profiles
{
    public class DetallesEntradasProfile: Profile
    {
        public DetallesEntradasProfile()
        {
            DetallesEntradasMapper(CreateMap<DetalleEntrada, DetalleEntradaDo>());
        }

        private void DetallesEntradasMapper(IMappingExpression<DetalleEntrada, DetalleEntradaDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Disponibles, act => act.MapFrom(src => src.Disponibles))
                .ForMember(dest => dest.TipoAsiento, act => act.MapFrom(src => src.TipoAsiento))
                .ForMember(dest => dest.Precio, act => act.MapFrom(src => src.Precio));
        }

    }
}
