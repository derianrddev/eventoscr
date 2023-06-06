 using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BZPAY_BE.Services.Interfaces;
using BZPAY_BE.Repositories.Implementations;
using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BZPAY_BE.Services.Implementations
{
    /// <summary>
    /// Service for Compra
    /// </summary>
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IConfiguration _config;

        public CompraService()
        {
        }

        /// <summary>
        /// Constructor of CompraService
        /// </summary>
        /// <param name="compraRepository"></param>
        public CompraService(ICompraRepository compraRepository, IConfiguration config)
        {
            _compraRepository = compraRepository;
            _config = config;   
        }

        public async Task<IEnumerable<Compra>> GetAllComprasAsync()
        {
            var lista = await _compraRepository.GetAllComprasAsync();
            return lista;
        }

        public async Task<Compra> GetCompraByIdAsync(int? id)
        {
             var lista = await _compraRepository.GetCompraByIdAsync(id);
             return lista;
        }

        public async Task<Compra> GetCompraAnteriorByIdAsync(int? id)
        {
            var lista = await _compraRepository.GetCompraByIdAsync(id);
            return lista;
        }

        public async Task<IEnumerable<Compra>> GetCompraByIdClienteAsync(string? id)
        {
            var lista = await _compraRepository.GetCompraByIdClienteAsync(id);
            return lista;
        }

        public async Task<Compra> CreateCompraAsync(Compra compra)
        {
            compra.Active = true;
            var lista = await _compraRepository.AddAsync(compra);
            return lista;
        }

        public async Task<Compra> UpdateCompraAsync(Compra compra)
        {
            DateTime currentDateTime = DateTime.Now;
            compra.UpdatedAt = currentDateTime;
            var lista = await _compraRepository.UpdateAsync(compra);
            return lista;
        }

        public async Task<IEnumerable<ImprimirEntrada>> GetCompraByClienteAsync(string? idCliente)
        {
            var lista = await _compraRepository.GetCompraByClienteAsync(idCliente);
            return lista;
        }

        public DateTime GetFechaReserva(int? id)
        {
            var fechaReserva = _compraRepository.GetFechaReserva(id);
            return fechaReserva;
        }

        public async Task<List<Compra>> GetEntradaCompradaByIdAsync(int? id)
        {
            var lista = await _compraRepository.GetEntradaCompradaByIdAsync(id);
            return lista;
        }
    }
}