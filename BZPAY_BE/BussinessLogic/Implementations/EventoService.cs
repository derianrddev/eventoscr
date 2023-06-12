using Microsoft.Extensions.Configuration;
using BZPAY_BE.BussinessLogic.Interfaces;
using BZPAY_BE.Repositories.Implementations;
using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BZPAY_BE.DataAccess;
using AutoMapper;

namespace BZPAY_BE.BussinessLogic.Implementations
{
    /// <summary>
    /// Service for Evento
    /// </summary>
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor of EventoService
        /// </summary>
        /// <param name="eventoRepository"></param>
        public EventoService(IEventoRepository eventoRepository, IMapper mapper, IConfiguration config)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
            _config = config;   
        }

        public async Task<IEnumerable<EventoDo?>> GetAllEventosAsync()
        {
            var lista = await _eventoRepository.GetAllEventosDescripAsync();
            if (lista == null) return null;
            //var tempList = lista.FirstOrDefault();
            var listaEventosDo = lista.Select(evento => _mapper.Map<EventoDo?>(evento)).ToList();
            return listaEventosDo;
        }

        public async Task<EventoDo?> GetEventoByIdAsync(int? id)
        {
            var evento = await _eventoRepository.GetEventoByIdDescripAsync(id);
            var eventoDo = _mapper.Map<EventoDo?>(evento);
            return eventoDo;
        }

        //public async Task<EventoDo?> CreateEventoAsync(Evento evento)
        //{
        //    evento.Active = true;
        //    var lista = await _eventoRepository.AddAsync(evento);
        //    var eventoDo = _mapper.Map<EventoDo>(lista);
        //    return eventoDo;
        //}

        //public async Task<EventoDo?> UpdateEventoAsync(Evento evento)
        //{
        //    DateTime currentDateTime = DateTime.Now;
        //    evento.UpdatedAt = currentDateTime;
        //    var lista = await _eventoRepository.UpdateAsync(evento);
        //    var eventoDo = _mapper.Map<EventoDo>(lista);
        //    return eventoDo;
        //}

        public async Task<IEnumerable<DetalleEventoDo?>> GetAllDetalleEventosAsync()
        {
            var lista = await _eventoRepository.GetAllDetalleEventosAsync();
            var listaDetalleEventosDo = lista.Select(detalleEvento => _mapper.Map<DetalleEventoDo?>(detalleEvento)).ToList();
            return listaDetalleEventosDo;
  
        }

        public async Task<DetalleEventoDo?> GetDetalleEventosByIdAsync(int? id)
        {
            var detalleEvento = await _eventoRepository.GetDetalleEventosByIdAsync(id);
            var detalleEventoDo = _mapper.Map<DetalleEventoDo?>(detalleEvento);
            return detalleEventoDo;
        }

        //public async Task<IEnumerable<DetalleAsiento>> GetDetalleAsientosAsync(int? id)
        //{
        //    var eventoAsientos = await _eventoRepository.GetDetalleAsientosAsync(id);
        //    return eventoAsientos;
        //}

    }
}