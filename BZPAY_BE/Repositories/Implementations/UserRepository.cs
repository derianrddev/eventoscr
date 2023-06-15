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

        //public async Task<User?> RegisterUserAsync(RegisterRequest register, string userId, string hashedPassword)
        //{
        //    var user = new User
        //    {
        //        Id = userId,
        //        FechaReserva = DateTime.Now,
        //        CreatedAt = DateTime.Now,
        //        CreatedBy = userId,
        //        UpdatedAt = DateTime.Now,
        //        UpdatedBy = userId,
        //        Active = true,
        //        IdCliente = userId,
        //        IdEntrada = idEntrada
        //    };

        //    //User user = await _context.User.Where(u => u.UserName == username).SingleOrDefaultAsync();
        //    return user;
        //}

        public async Task<User?> GetUserByIdAsync(string id)
        {
            User user = await _context.Users
                .SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<IEnumerable<User?>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<IEnumerable<DetalleUsuarios?>> GetAllDetalleUsuariosAsync()
        {
            var detalleUsuarios = await (from us in _context.Users
                                join ur in _context.UserRoles on us.Id equals ur.UserId
                                join ro in _context.Role on ur.RoleId equals ro.Id
                                select new DetalleUsuarios
                                {
                                    Id = us.Id,
                                    UserName = us.UserName,
                                    Email = us.Email,
                                    PasswordHash = us.PasswordHash,
                                    SecurityStamp = us.SecurityStamp,
                                    ConcurrencyStamp = us.ConcurrencyStamp,
                                    PhoneNumber = us.PhoneNumber,
                                    RoleName = ro.Name
                                }).ToListAsync();
            
            return detalleUsuarios;
        }

        public async Task<DetalleUsuarios?> GetDetalleUsuariosByIdAsync(string id)
        {
            var detalleUsuarios = await (from us in _context.Users
                                         join ur in _context.UserRoles on us.Id equals ur.UserId
                                         join ro in _context.Role on ur.RoleId equals ro.Id
                                         where us.Id == id
                                         select new DetalleUsuarios
                                         {
                                             Id = us.Id,
                                             UserName = us.UserName,
                                             Email = us.Email,
                                             PasswordHash = us.PasswordHash,
                                             SecurityStamp = us.SecurityStamp,
                                             ConcurrencyStamp = us.ConcurrencyStamp,
                                             PhoneNumber = us.PhoneNumber,
                                             RoleName = ro.Name
                                         }).FirstOrDefaultAsync();
            return detalleUsuarios;
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
            //var userRole = await _context.UserRoles.FindAsync(userId);
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();

                var newUserRole = new UserRoles
                {
                    UserId = userId,
                    RoleId = roleId
                };

                _context.UserRoles.Add(newUserRole);
                await _context.SaveChangesAsync();

                return newUserRole;
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

        public async Task<IEnumerable<Role?>> GetAllRolesAsync()
        {
            var roles = await _context.Role.ToListAsync();
            return roles;
        }
    }
}