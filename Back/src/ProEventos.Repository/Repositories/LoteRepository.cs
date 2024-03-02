using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Repository.Interfaces;

namespace ProEventos.Repository.Repositories;

public class LoteRepository : ILoteRepository
{
  private readonly DataContext _context;

  public LoteRepository(DataContext context)
  {
    _context = context;
  }

  public async Task<Lote> GetLoteByIdsAsync(int eventoId, int id)
  {
    IQueryable<Lote> query = _context.Lotes;

    query = query.AsNoTracking()
                  .Where(lote => lote.EventoId == eventoId
                              && lote.Id == id);

    return await query.FirstOrDefaultAsync();
  }

  public async Task<Lote[]> GetLotesByEventoIdAsync(int eventoId)
  {
    IQueryable<Lote> query = _context.Lotes;

    query = query.AsNoTracking()
                  .Where(lote => lote.EventoId == eventoId);

    return await query.ToArrayAsync();
  }
}
