using BZPAY_BE.Repositories;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.Services.Interfaces
{
    /// <summary>
    /// Service Interface for Escenario. 
    /// </summary>
    
    public interface IEscenarioService
    {
        Task<IEnumerable<Escenario>> GetAllEscenariosAsync();

        Task<Escenario> GetEscenariosByIdAsync(int? id);

        Task<Escenario> CreateEscenariosAsync(Escenario escenario);

        Task<Escenario> UpdateEscenariosAsync(Escenario escenario);


    }
}
