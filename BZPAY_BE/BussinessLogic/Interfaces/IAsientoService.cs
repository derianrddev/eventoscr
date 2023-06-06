using BZPAY_BE.Repositories;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.Interfaces
{
    /// <summary>
    /// Service Interface for Asiento. 
    /// </summary>
    
    public interface IAsientoService
    {
        Task<IEnumerable<Asiento>> GetAllAsientosAsync();

        Task<Asiento> GetAsientosByIdAsync(int? id);

        Task<Asiento> CreateAsientosAsync(Asiento asiento);

        Task<Asiento> UpdateAsientosAsync(Asiento asiento);


    }
}
