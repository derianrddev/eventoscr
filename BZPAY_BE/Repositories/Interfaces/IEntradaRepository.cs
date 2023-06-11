using BZPAY_BE.Repositories.Implementations;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for Entrada
    /// </summary>
    public interface IEntradaRepository : IGenericRepository<Entrada>
    {
        Task<IEnumerable<Entrada>> GetAllEntradasAsync();

        Task<Entrada> GetEntradaByIdAsync(int? id);

        Task<Entrada> GetEntradaByEventoAndAsientoAsync(int? idAsiento, int? idEvento);

        Task<IEnumerable<DetalleEntrada>> GetDetalleEntradasAsync(int? idEvento);


    }

    
}

