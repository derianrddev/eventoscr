using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;

namespace BZPAY_BE.Common.Profiles
{
    public class UserRolesProfile: Profile

    {
        public UserRolesProfile()
        {
            UserRolesMapper(CreateMap<UserRoles, UserRolesDo>());
        }

        private void UserRolesMapper(IMappingExpression<UserRoles, UserRolesDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.UserId, act => act.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoleId, act => act.MapFrom(src => src.RoleId));
        }

    }
}
