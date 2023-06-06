using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for Tipoescenario
    /// </summary>
    public class TipoEscenarioRepository : GenericRepository<TipoEscenario>, ITipoEscenarioRepository
    {
        /// <summary>
        /// Constructor of TipoEscenarioRepository
        /// </summary>
        /// <param name="Proyecto1SpecialTicketContext"></param>
        public TipoEscenarioRepository(SpecialticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<TipoEscenario>> GetAllTipoEscenariosAsync()
        {
            return await _context.TipoEscenarios
                                 .Include(t => t.IdEscenarioNavigation)
                                 .Where(t => t.Active)
                                 .ToListAsync();
        }

        public async Task<TipoEscenario> GetTipoEscenarioByIdAsync(int id)
        {
            return await _context.TipoEscenarios
                                 .Where(t => t.Active)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}