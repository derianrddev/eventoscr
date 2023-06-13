using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;

namespace BZPAY_BE.Common.Profiles
{
    public class DetalleUsuariosProfile: Profile
    {
        public DetalleUsuariosProfile()
        {
            DetalleUsuarioMapper(CreateMap<DetalleUsuarios, DetalleUsuariosDo>());
        }

        private void DetalleUsuarioMapper(IMappingExpression<DetalleUsuarios, DetalleUsuariosDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, act => act.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.SecurityStamp, act => act.MapFrom(src => src.SecurityStamp))
                .ForMember(dest => dest.ConcurrencyStamp, act => act.MapFrom(src => src.ConcurrencyStamp))
                .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.RoleName, act => act.MapFrom(src => src.RoleName));
        }
    }
}
