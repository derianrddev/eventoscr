using BZPAY_BE.Repositories.Implementations;
using BZPAY_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for Evento
    /// </summary>
    public interface ITipoEscenarioRepository : IGenericRepository<TipoEscenario>
    {
        Task<IEnumerable<TipoEscenario>> GetAllTipoEscenariosAsync();

        Task<TipoEscenario> GetTipoEscenarioByIdAsync(int id);
    }

}

