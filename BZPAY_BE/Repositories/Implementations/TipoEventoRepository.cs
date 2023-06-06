using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for TipoEvento
    /// </summary>
    public class TipoEventoRepository : GenericRepository<TipoEvento>, ITipoEventoRepository
    {
        /// <summary>
        /// Constructor of TipoEventoRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public TipoEventoRepository(SpecialticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<TipoEvento>> GetAllTipoEventosAsync()
        {
            return await _context.TipoEventos
                                 .Where(t => t.Active)
                                 .ToListAsync();
        }

        public async Task<TipoEvento> GetTipoEventoByIdAsync(int? id)
        {
            return await _context.TipoEventos
                                 .Where(t => t.Active)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}