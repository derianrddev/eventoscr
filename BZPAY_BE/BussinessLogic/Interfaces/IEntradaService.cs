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
    /// Service Interface for Entrada. 
    /// </summary>
    
    public interface IEntradaService
    {
        Task<IEnumerable<EntradaDo?>> GetAllEntradasAsync();

        //Task<Entrada> GetEntradaByIdAsync(int? id);

        //Task<Entrada> GetEntradaByEventoAndAsientoAsync(int? idAsiento, int? idEvento);

        Task<EntradaDo?> CreateEntradaAsync(Entrada entrada, string userId);

        Task<EntradaDo?> UpdateEntradaAsync(Entrada entrada);

        Task<IEnumerable<DetalleEntrada>> GetDetalleEntradasAsync(int? id);

        //Task<Entrada> CreateEntradasAsync(IFormCollection form);

    }
}
