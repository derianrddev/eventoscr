using Microsoft.AspNetCore.Http;
using BZPAY_BE.Repositories;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using BZPAY_BE.DataAccess;

namespace BZPAY_BE.Services.Interfaces
{
    /// <summary>
    /// Service Interface for Compra. 
    /// </summary>
    
    public interface ICompraService
    {
        //Task<IEnumerable<Compra>> GetAllComprasAsync();

        //Task<Compra> GetCompraByIdAsync(int? id);

        //Task<Compra> GetCompraAnteriorByIdAsync(int? id);

        Task<IEnumerable<CompraDo?>> GetCompraByIdClienteAsync(string? id);

        Task<CompraDo?> CreateCompraAsync(int cantidad, int idEntrada, string userId);

        //Task<Compra> UpdateCompraAsync(Compra compra);

        Task<IEnumerable<ImprimirEntrada>> GetCompraByClienteAsync(string? idCliente);

        //DateTime GetFechaReserva(int? id);

        //Task<List<Compra>> GetEntradaCompradaByIdAsync(int? id);

    }
}
