using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models.Entities;

namespace BZPAY_BE.Common.Profiles
{
    public class DetalleAsientosProfile: Profile
    {
        public DetalleAsientosProfile() 
        { 
            DetallesAsientosMapper(CreateMap<DetalleAsiento, DetalleAsientoDo>());
        }

        private void DetallesAsientosMapper(IMappingExpression<DetalleAsiento, DetalleAsientoDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdEvento, act => act.MapFrom(src => src.IdEvento))
                .ForMember(dest => dest.TipoAsiento, act => act.MapFrom(src => src.TipoAsiento))
                .ForMember(dest => dest.Cantidad, act => act.MapFrom(src => src.Cantidad));
        }

    }
}
