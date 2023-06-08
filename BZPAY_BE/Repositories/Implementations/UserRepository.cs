using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for AspnetMembership
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        /// <summary>
        /// Constructor of AspnetUserRepository
        /// </summary>
        /// <param name="membershipContext"></param>
        public UserRepository(SpecialticketContext specialticketContext) : base(specialticketContext)
        {
        }       

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            User user = await _context.Users
                //.Include(x => x.AspnetMembership)
                .SingleOrDefaultAsync(x => x.UserName == username);

            //User user = await _context.User.Where(u => u.UserName == username).SingleOrDefaultAsync();
            return user;
        }
    }
}