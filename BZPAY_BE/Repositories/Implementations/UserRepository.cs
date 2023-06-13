using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using BZPAY_BE.Models.Entities;
using BZPAY_BE.DataAccess;

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

        public async Task<User?> GetUserByIdAsync(string id)
        {
            User user = await _context.Users
                .SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<IEnumerable<User?>> GetUsersWithReservationsAsync()
        {
            DateTime defaultDate = DateTime.Parse("0001-01-01 00:00:00");

            var usersWithReservations = await (from us in _context.Users
                                          join c in _context.Compras on us.Id equals c.IdCliente
                                          where c.FechaPago == defaultDate
                                          select us).Distinct().ToListAsync();

            return usersWithReservations;
        }

        public async Task<UserRoles?> ChangeRoleToUserAsync(string userId, string roleId)
        {
            var userRole = await _context.UserRoles.FindAsync(userId);

            if (userRole != null)
            {
                userRole.RoleId = roleId;

                await _context.SaveChangesAsync();

                return userRole;
            }
            else
            {
                var newUserRole = new UserRoles
                {
                    UserId = userId,
                    RoleId = roleId
                };

                _context.UserRoles.Add(newUserRole);
                await _context.SaveChangesAsync();
                
                return newUserRole;
            }


        }
    }
}