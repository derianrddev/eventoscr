using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.auth.ServiceInterface
{
    /// <summary>
    /// Service Interface for Users. 
    /// </summary>
    
    public interface IUserService
    {
        Task<UserDo?> StartSessionAsync(LoginRequest login);
        Task<UserDo?> RegisterAsync(RegisterRequest register);
        Task<UserDo?> GetUserByUserNameAsync(string username);
        Task<UserDo?> GetUserByIdAsync(string id);
        Task<IEnumerable<UserDo?>> GetAllUsersAsync();
        Task<IEnumerable<DetalleUsuariosDo?>> GetAllDetalleUsuariosAsync();
        Task<DetalleUsuariosDo?> GetDetalleUsuariosByIdAsync(string id);
        Task<IEnumerable<UserDo?>> GetUsersWithReservationsAsync();
        Task<UserRolesDo?> ChangeRoleToUserAsync(string userId, string roleId);
        Task<IEnumerable<RoleDo?>> GetAllRolesAsync();
        //Task<User?> ForgotPasswordAsync(string username);
        //Task<User?> UpdatePasswordAsync(UpdatePasswordRequest data);
    }
}
