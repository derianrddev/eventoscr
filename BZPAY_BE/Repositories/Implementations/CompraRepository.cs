using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BZPAY_BE.Models.Entities;
using BZPAY_BE.DataAccess;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for Compra
    /// </summary>
    public class CompraRepository : GenericRepository<Compra>, ICompraRepository
    {
        /// <summary>
        /// Constructor of CompraRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public CompraRepository(SpecialticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<Compra>> GetAllComprasAsync()
        {
            return await _context.Compras
                                 .Where(x=>x.Active)
                                 .ToListAsync();
        }

        public async Task<Compra> GetCompraByIdAsync(int? id)
        {
            var compra = await _context.Compras
                                 .Where(t => t.Active)
                                 .FirstOrDefaultAsync(m => m.Id == id);

            return compra;
        }

        public async Task<Compra> GetCompraAnteriorByIdAsync(int? id)
        {
            var compra = await _context.Compras
                                     .AsNoTracking()
                                     .Where(t => t.Active)
                                     .FirstOrDefaultAsync(m => m.Id == id);

            return compra;
        }

        public async Task<IEnumerable<Compra>> GetCompraByIdClienteAsync(string? id)
        {
            var compra = await _context.Compras
                                 .Where(t => t.Active && t.IdCliente == id)
                                 .ToListAsync();

            return compra;
        }

        public async Task<IEnumerable<ImprimirEntrada>> GetCompraByClienteAsync(string? idCliente)
        {
            var entradasReservadas = await _context.Compras
                                    .Where(c => c.IdCliente == idCliente && c.Active == true)
                                    .Join(_context.Entradas, c => c.IdEntrada, en => en.Id, (c, en) => new { Compra = c, Entrada = en })
                                    .Join(_context.Eventos, ce => ce.Entrada.IdEvento, ev => ev.Id, (ce, ev) => new { CompraEntrada = ce, Evento = ev })
                                    .Select(cev => new ImprimirEntrada
                                    {
                                        Id = cev.CompraEntrada.Compra.Id,
                                        Cantidad = cev.CompraEntrada.Compra.Cantidad,
                                        FechaReserva = cev.CompraEntrada.Compra.FechaReserva,
                                        FechaPago = cev.CompraEntrada.Compra.FechaPago,
                                        TipoAsiento = cev.CompraEntrada.Entrada.TipoAsiento,
                                        Precio = cev.CompraEntrada.Entrada.Precio,
                                        Total = cev.CompraEntrada.Entrada.Precio * cev.CompraEntrada.Compra.Cantidad,
                                        Evento = cev.Evento.Descripcion
                                    }).ToListAsync();

            return entradasReservadas;
        }

        public DateTime GetFechaReserva(int? id)
        {
            var fechaReserva = _context.Compras
                        .Where(te => te.Id == id)
                        .Select(te => te.FechaReserva)
                        .FirstOrDefault();

            return fechaReserva;
        }

        public async Task<List<Compra>> GetEntradaCompradaByIdAsync(int? id)
        {
            var listaEntradaComprada = await _context.Compras
                                    .Where(c => c.Id == id)
                                    .Select(cev => new Compra
                                    {
                                        Id = cev.Id,
                                        Cantidad = cev.Cantidad,
                                        FechaReserva = cev.FechaReserva,
                                        FechaPago = cev.FechaPago,
                                        CreatedAt = cev.CreatedAt,
                                        CreatedBy = cev.CreatedBy,
                                        UpdatedAt = cev.UpdatedAt,
                                        UpdatedBy = cev.UpdatedBy,
                                        Active = cev.Active,
                                        IdCliente = cev.IdCliente,
                                        IdEntrada = cev.IdEntrada
                                    }).ToListAsync();

            return listaEntradaComprada;
        }

        public async Task<ImprimirEntrada> ImprimirEntradaAsync(int? idCompra)
        {
            DateTime currentDateTime = DateTime.Now;
            var compra = await _context.Compras.FindAsync(idCompra);
            compra.FechaPago = currentDateTime;

            await _context.SaveChangesAsync();

            var entradaComprada = await (from c in _context.Compras
                                         join us in _context.Users on c.IdCliente equals us.Id
                                         join en in _context.Entradas on c.IdEntrada equals en.Id
                                         join ev in _context.Eventos on en.IdEvento equals ev.Id
                                         join te in _context.TipoEventos on ev.IdTipoEvento equals te.Id
                                         join es in _context.Escenarios on ev.IdEscenario equals es.Id
                                         where c.Id == idCompra
                                         select new ImprimirEntrada
                                         {
                                             Id = c.Id,
                                             Cantidad = c.Cantidad,
                                             FechaReserva = c.FechaReserva,
                                             FechaPago = currentDateTime,
                                             TipoAsiento = en.TipoAsiento,
                                             Precio = en.Precio,
                                             Total = en.Precio * c.Cantidad,
                                             Evento = ev.Descripcion,
                                             Escenario = es.Nombre,
                                             IdCliente = c.IdCliente,
                                             UserName = us.UserName,
                                         }).FirstOrDefaultAsync();
            return entradaComprada;
        }
    }
}