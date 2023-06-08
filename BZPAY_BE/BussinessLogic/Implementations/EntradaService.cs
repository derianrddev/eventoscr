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
        private readonly UserManager<Proyecto1specialticketuser> _userManager;

        public EntradaService()
        {
        }

        /// <summary>
        /// Constructor of EntradaService
        /// </summary>
        /// <param name="entradaRepository"></param>
        public EntradaService(IEntradaRepository entradaRepository, IMapper mapper, IConfiguration config, UserManager<Proyecto1specialticketuser> userManager)
        {
            _entradaRepository = entradaRepository;
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
        }

        //public async Task<IEnumerable<Entrada>> GetAllEntradasAsync()
        //{
        //    var lista = await _entradaRepository.GetAllEntradasAsync();
        //    return lista;
        //}

        //public async Task<Entrada> GetEntradaByIdAsync(int? id)
        //{
        //     var lista = await _entradaRepository.GetEntradaByIdAsync(id);
        //     return lista;
        //}

        //public async Task<Entrada> GetEntradaByEventoAndAsientoAsync(int? idAsiento, int? idEvento)
        //{
        //    var lista = await _entradaRepository.GetEntradaByEventoAndAsientoAsync(idAsiento, idEvento);
        //    return lista;
        //}

        public async Task<EntradaDo?> CreateEntradaAsync(Entrada entrada)
        {
            entrada.Active = true;
            //var userId = _userManager.GetUserId(User);
            //entrada.CreatedBy = userId;
            //entrada.UpdatedBy = userId;
            var lista = await _entradaRepository.AddAsync(entrada);
            var entradaDo = _mapper.Map<EntradaDo?>(lista);
            return entradaDo;
        }

        public async Task<EntradaDo?> UpdateEntradaAsync(Entrada entrada)
        {
            DateTime currentDateTime = DateTime.Now;
            entrada.UpdatedAt = currentDateTime;
            var lista = await _entradaRepository.UpdateAsync(entrada);
            var entradaDo = _mapper.Map<EntradaDo?>(lista);
            return entradaDo;
        }

        public async Task<IEnumerable<DetalleEntrada>> GetDetalleEntradasAsync(int? id)
        {
            var lista = await _entradaRepository.GetDetalleEntradasAsync(id);
            return lista;
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