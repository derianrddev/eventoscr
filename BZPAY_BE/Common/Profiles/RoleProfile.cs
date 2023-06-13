using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;

namespace BZPAY_BE.Common.Profiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            RoleMapper(CreateMap<Role, RoleDo>());
        }
        private void RoleMapper(IMappingExpression<Role, RoleDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                                .ForMember(dest => dest.NormalizedName, act => act.MapFrom(src => src.NormalizedName))
                                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.MapFrom(src => src.ConcurrencyStamp));
        }

    }
}
