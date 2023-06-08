using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;

namespace BZPAY_BE.Common.Profiles
{
    public class EntradaProfile: Profile
    {

        public EntradaProfile()
        {
            EntradaMapper(CreateMap<Entrada, EntradaDo>());
        }

        private void EntradaMapper(IMappingExpression<Entrada, EntradaDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Disponibles, act => act.MapFrom(src => src.Disponibles))
                .ForMember(dest => dest.TipoAsiento, act => act.MapFrom(src => src.TipoAsiento))
                .ForMember(dest => dest.Precio, act => act.MapFrom(src => src.Precio))
                .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.UpdatedBy, act => act.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Active, act => act.MapFrom(src => src.Active))
                .ForMember(dest => dest.IdEvento, act => act.MapFrom(src => src.IdEvento));
        }

    }
}
