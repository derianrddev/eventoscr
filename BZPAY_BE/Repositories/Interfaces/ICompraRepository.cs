using BZPAY_BE.Repositories.Implementations;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for Compra
    /// </summary>
    public interface ICompraRepository : IGenericRepository<Compra>
    {
        Task<IEnumerable<Compra>> GetAllComprasAsync();

        Task<Compra> GetCompraByIdAsync(int? id);

        Task<Compra> GetCompraAnteriorByIdAsync(int? id);

        Task<IEnumerable<Compra>> GetCompraByIdClienteAsync(string? id);

        Task<IEnumerable<ImprimirEntrada>> GetCompraByClienteAsync(string? idCliente);

        DateTime GetFechaReserva(int? id);

        Task<List<Compra>> GetEntradaCompradaByIdAsync(int? id);
    }

    
}

