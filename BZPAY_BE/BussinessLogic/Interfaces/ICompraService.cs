using Microsoft.AspNetCore.Http;
using BZPAY_BE.Repositories;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.Services.Interfaces
{
    /// <summary>
    /// Service Interface for Compra. 
    /// </summary>
    
    public interface ICompraService
    {
        Task<IEnumerable<Compra>> GetAllComprasAsync();

        Task<Compra> GetCompraByIdAsync(int? id);

        Task<Compra> GetCompraAnteriorByIdAsync(int? id);

        Task<IEnumerable<Compra>> GetCompraByIdClienteAsync(string? id);

        Task<Compra> CreateCompraAsync(Compra compra);

        Task<Compra> UpdateCompraAsync(Compra compra);

        Task<IEnumerable<ImprimirEntrada>> GetCompraByClienteAsync(string? idCliente);

        DateTime GetFechaReserva(int? id);

        Task<List<Compra>> GetEntradaCompradaByIdAsync(int? id);

    }
}
