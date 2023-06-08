using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;

namespace BZPAY_BE.Common.Profiles
{
    public class EventoProfile: Profile
    {
        public EventoProfile()
        {
            EventoMapper(CreateMap<Evento, EventoDo>());
        }

        private void EventoMapper(IMappingExpression<Evento, EventoDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descripcion, act => act.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Fecha, act => act.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.UpdatedBy, act => act.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Active, act => act.MapFrom(src => src.Active))
                .ForMember(dest => dest.IdTipoEvento, act => act.MapFrom(src => src.IdTipoEvento))
                .ForMember(dest => dest.IdEscenario, act => act.MapFrom(src => src.IdEscenario));
        }

    }
}
