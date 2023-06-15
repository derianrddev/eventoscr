using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for Users
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByUserNameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        User? CreateObjToRegisterUser(RegisterRequest register);
        Task<User?> GetUserByIdAsync(string id);
        Task<IEnumerable<User?>> GetAllUsersAsync();
        Task<IEnumerable<DetalleUsuarios?>> GetAllDetalleUsuariosAsync();
        Task<DetalleUsuarios?> GetDetalleUsuariosByIdAsync(string id);
        Task<IEnumerable<User?>> GetUsersWithReservationsAsync();
        Task<UserRoles?> ChangeRoleToUserAsync(string userId, string roleId);
        Task<IEnumerable<Role?>> GetAllRolesAsync();
        Task<Role?> GetRolesbyNameAsync(string name);
    }

}

