using BZPAY_BE.Repositories;
using BZPAY_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BZPAY_BE.DataAccess;

namespace BZPAY_BE.BussinessLogic.Interfaces
{
    /// <summary>
    /// Service Interface for Evento. 
    /// </summary>
    
    public interface IEventoService
    {
        Task<IEnumerable<EventoDo?>> GetAllEventosAsync();

        Task<EventoDo?> GetEventoByIdAsync(int? id);

        //Task<EventoDo?> CreateEventoAsync(Evento evento);

        //Task<EventoDo?> UpdateEventoAsync(Evento evento);

        Task<IEnumerable<DetalleEventoDo?>> GetAllDetalleEventosAsync();

        Task<DetalleEventoDo?> GetDetalleEventosByIdAsync(int? id);

        //Task<IEnumerable<DetalleAsiento>> GetDetalleAsientosAsync(int? id);

        //Task<Evento> GetDetallesEventosAsync();

    }
}
