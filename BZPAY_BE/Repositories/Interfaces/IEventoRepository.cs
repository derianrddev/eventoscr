using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using BZPAY_BE.DataAccess;

namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for Evento
    /// </summary>
    public interface IEventoRepository : IGenericRepository<Evento>
    {
        Task<IEnumerable<Evento>> GetAllEventosAsync();
        Task<IEnumerable<EventoDo>> GetAllEventosDescripAsync();
        Task<Evento> GetEventoByIdAsync(int? id);
        Task<EventoDo> GetEventoByIdDescripAsync(int? id);
        Task<IEnumerable<DetalleEvento>> GetAllDetalleEventosAsync();
        Task<DetalleEvento> GetDetalleEventosByIdAsync(int? id);
        Task<IEnumerable<DetalleAsiento>> GetDetalleAsientosAsync(int? id);
    }

    
}

