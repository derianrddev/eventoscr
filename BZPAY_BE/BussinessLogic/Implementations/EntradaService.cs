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
using BZPAY_BE.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace BZPAY_BE.Services.Implementations
{
    /// <summary>
    /// Service for Entrada
    /// </summary>
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public EntradaService()
        {
        }

        /// <summary>
        /// Constructor of EntradaService
        /// </summary>
        /// <param name="entradaRepository"></param>
        public EntradaService(IEntradaRepository entradaRepository, IMapper mapper, IConfiguration config)
        {
            _entradaRepository = entradaRepository;
            _mapper = mapper;
            _config = config;

        }

        public async Task<IEnumerable<EntradaDo?>> GetAllEntradasAsync()
        {
            var lista = await _entradaRepository.GetAllEntradasAsync();
            if (lista == null) return null;
            var listaEntradasDo = lista.Select(entrada => _mapper.Map<EntradaDo?>(entrada)).ToList();
            return listaEntradasDo;
        }

        public async Task<EntradaDo?> GetEntradaByIdAsync(int? id)
        {
            var entrada = await _entradaRepository.GetEntradaByIdAsync(id);
            var entradaDo = _mapper.Map<EntradaDo?>(entrada);
            return entradaDo;
        }


        //public async Task<Entrada> GetEntradaByEventoAndAsientoAsync(int? idAsiento, int? idEvento)
        //{
        //    var lista = await _entradaRepository.GetEntradaByEventoAndAsientoAsync(idAsiento, idEvento);
        //    return lista;
        //}

        public async Task<EntradaDo?> CreateEntradaAsync(int disponibles, string tipoAsiento, decimal precio, 
            int idEvento, string userId)
        {
            var entrada = new Entrada
            {
                Disponibles = disponibles,
                TipoAsiento = tipoAsiento,
                Precio = precio,
                CreatedAt = DateTime.Now,
                CreatedBy = userId,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId,
                Active = true,
                IdEvento = idEvento,
            };

            var nuevaEntrada = await _entradaRepository.AddAsync(entrada);
            var entradaDo = _mapper.Map<EntradaDo?>(nuevaEntrada);
            return entradaDo;
        }

        public async Task<EntradaDo?> UpdateEntradaAsync(EntradaDo entradaDo, string userId)
        {
            var entradaActualizada = await _entradaRepository.UpdateEntradaAsync(entradaDo, userId);
            var entradaDoActualizado = _mapper.Map<EntradaDo?>(entradaActualizada);
            return entradaDoActualizado;
        }

        public async Task<IEnumerable<DetalleEntradaDo?>> GetDetalleEntradasAsync(int? idEvento)
        {
            var lista = await _entradaRepository.GetDetalleEntradasAsync(idEvento);
            if (lista == null) return null;
            var listaEntradasDo = lista.Select(detalleEntrada => _mapper.Map<DetalleEntradaDo?>(detalleEntrada)).ToList();
            return listaEntradasDo;
        }

        //public async Task<Entrada> CreateEntradasAsync(IFormCollection collection)
        //{
        //    var form = collection.ToList();
        //    var idEvento = Int32.Parse(form[0].Value);
        //    //verificar primero si ya existen las entradas porque solo se pueden crear una vez
        //    var entradasEvento = await _entradaRepository.GetEntradaByIdEventoAsync(idEvento);
        //    if (entradasEvento == null)//si entradas no han sido creadas --> crearlas
        //    {
        //        var descripciones = form[1].Value.ToList();
        //        var cantidades = form[2].Value.ToList();
        //        var precios = form[3].Value.ToList();
        //        for (var i = 0; i < descripciones.Count(); i++)
        //        {
        //            var entrada = new Entrada();
        //            entrada.IdEvento = idEvento;
        //            entrada.TipoAsiento = descripciones[i];
        //            entrada.Disponibles = Int32.Parse(cantidades[i]);
        //            entrada.Precio = Decimal.Parse(precios[i]);
        //            entrada.Active = true;
        //            await _entradaRepository.AddAsync(entrada);
        //        }
        //    }
        //    return entradasEvento;
        //}

    }
}