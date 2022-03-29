using AutoMapper;
using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;



namespace BZPAY_BE.BussinessLogic.auth.ServiceImplementation
{
    /// <summary>
    /// Service for Aspnet Users
    /// </summary>
    public class AspnetUserService : IAspnetUserService
    {
        private readonly IAspnetUserRepository _aspnetUserRepository;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Constructor of AspnetUserService
        /// </summary>
        /// <param name="aspnetUserRepository"></param>
        /// <param name="mapper"></param>
        public AspnetUserService(IAspnetUserRepository aspnetUserRepository, IMapper mapper)
        {
            _aspnetUserRepository = aspnetUserRepository;
            _mapper = mapper;
        }

        public async Task<AspnetUserDo?> IniciarSesionAsync(LoginRequest login)
        {
            var user = await _aspnetUserRepository.GetUserByUserNameAsync(login.Username);
            if (user == null) return null;
            var encrypt = EncodePassword(login.Password, 1, user.AspnetMembership.PasswordSalt);
            if (encrypt != user.AspnetMembership.Password)
                return null;
            var userDo = _mapper.Map<AspnetUserDo>(user); 
            userDo.Membership = _mapper.Map<AspnetMembershipDo>(user.AspnetMembership);
            return userDo;
        }

        private static string EncodePassword(string pass, int passwordFormat, string salt)
        {
            if (passwordFormat == 0)
                return pass;
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            byte[] inArray = null;
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            if (passwordFormat == 1)
            {
                HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
                if ((algorithm == null))
                {
                    throw new Exception("Invalid HashAlgoritm");
                }
                inArray = algorithm.ComputeHash(dst);
            }
            return Convert.ToBase64String(inArray);
        }
    }
}