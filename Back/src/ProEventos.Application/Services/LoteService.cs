using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;
using ProEventos.Repository.Interfaces;

namespace ProEventos.Application.Services;

// Camada de Logica de negocio, onde acessa os Repositorios (dados). Determina o comportamento que o Controller tera
// Os DTO`s devem estar apenas na camada Application
public class LoteService : ILoteService
{
  private readonly IProEventosGeneric _genericRepository;
  private readonly ILoteRepository _loteRepository;
  private readonly IMapper _mapper;

  public LoteService(IProEventosGeneric genericRepository,
                      ILoteRepository loteRepository,
                      IMapper mapper)
  {
    _genericRepository = genericRepository;
    _loteRepository = loteRepository;
    _mapper = mapper;
  }

  public async Task AddLote(int eventoId, LoteDto model)
  {
    try
    {
      var lote = _mapper.Map<Lote>(model);
      lote.EventoId = eventoId;

      _genericRepository.Add<Lote>(lote);

      await _genericRepository.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models)
  {
    try
    {
      var lotes = await _loteRepository.GetLotesByEventoIdAsync(eventoId);
      if (lotes == null) return null;

      foreach (var model in models)
      {
        if (model.Id == 0)
        {
          await AddLote(eventoId, model);
        }
        else
        {
          var lote = lotes.FirstOrDefault(lote => lote.Id == model.Id);
          model.EventoId = eventoId;

          _mapper.Map(model, lote);

          _genericRepository.Update<Lote>(lote);

          await _genericRepository.SaveChangesAsync();
        }
      }

      var loteRetorno = await _loteRepository.GetLotesByEventoIdAsync(eventoId);

      return _mapper.Map<LoteDto[]>(loteRetorno);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<bool> DeleteLote(int eventoId, int loteId)
  {
    try
    {
      var lote = await _loteRepository.GetLoteByIdsAsync(eventoId, loteId);
      if (lote == null) throw new Exception("Lote para delete não encontrado.");

      _genericRepository.Delete<Lote>(lote);
      return await _genericRepository.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId)
  {
    try
    {
      var lotes = await _loteRepository.GetLotesByEventoIdAsync(eventoId);
      if (lotes == null) return null;

      var resultado = _mapper.Map<LoteDto[]>(lotes);

      return resultado;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId)
  {
    try
    {
      var lote = await _loteRepository.GetLoteByIdsAsync(eventoId, loteId);
      if (lote == null) return null;

      var resultado = _mapper.Map<LoteDto>(lote);

      return resultado;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
