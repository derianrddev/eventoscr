using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
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
        Task<UserDo?> GetUserByUserNameAsync(string username);
        Task<UserDo?> GetUserByIdAsync(string id);
        //Task<User?> ForgotPasswordAsync(string username);
        //Task<User?> UpdatePasswordAsync(UpdatePasswordRequest data);
    }
}
