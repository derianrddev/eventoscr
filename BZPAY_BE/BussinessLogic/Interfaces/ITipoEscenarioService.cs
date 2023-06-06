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
    
    public interface ITipoEscenarioService
    {
        Task<IEnumerable<TipoEscenario>> GetAllTipoEscenariosAsync();

        Task<TipoEscenario> GetTipoEscenarioByIdAsync(int id);

        Task<TipoEscenario> CreateTipoEscenariosAsync(TipoEscenario tipoEscenario);

        Task<TipoEscenario> UpdateTipoEscenariosAsync(TipoEscenario tipoEscenario);


    }
}
