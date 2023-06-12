using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
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
        Task<User?> GetUserByIdAsync(string id);
        Task<IEnumerable<User?>> GetUsersWithReservationsAsync();
    }

}

