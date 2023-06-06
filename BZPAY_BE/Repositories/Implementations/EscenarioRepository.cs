using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for Escenario
    /// </summary>
    public class EscenarioRepository : GenericRepository<Escenario>, IEscenarioRepository
    {
        /// <summary>
        /// Constructor of EscenarioRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public EscenarioRepository(SpecialticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<Escenario>> GetAllEscenariosAsync()
        {
            return await _context.Escenarios.Where(t => t.Active).ToListAsync();
        }

        public async Task<Escenario> GetEscenarioByIdAsync(int? id)
        {
            var escenario = await _context.Escenarios
                                 .Where(t => t.Active)
                                 .FirstOrDefaultAsync(m => m.Id == id);

            return escenario;
        }
    }
}