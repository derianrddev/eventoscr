using BZPAY_BE.Repositories;
using BZPAY_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.Interfaces
{
    /// <summary>
    /// Service Interface for Evento. 
    /// </summary>
    
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> GetAllEventosAsync();

        Task<Evento> GetEventoByIdAsync(int? id);

        Task<Evento> CreateEventoAsync(Evento evento);

        Task<Evento> UpdateEventoAsync(Evento evento);

        //Task<IEnumerable<DetalleEvento>> GetDetalleEventosAsync();

        //Task<DetalleEvento> GetDetalleEventosByIdAsync(int? id);

        //Task<IEnumerable<DetalleAsiento>> GetDetalleAsientosAsync(int? id);

        //Task<Evento> GetDetallesEventosAsync();
        //Task<AspnetUserDo?> StartSessionAsync(LoginRequest login);
        //Task<AspnetUserDo?> ForgotPasswordAsync(string username);
        //Task<AspnetUserDo?> UpdatePasswordAsync(UpdatePasswordRequest data);
    }
}
