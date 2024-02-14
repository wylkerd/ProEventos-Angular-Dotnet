using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;
using ProEventos.Repository.Interfaces;

namespace ProEventos.Application.Services;

// Camada de Logica de negocio, onde acessa os Repositorios (dados). Determina o comportamento que o Controller tera
public class EventoService : IEventoService
{
  private readonly IProEventosGeneric _genericRepository;
  private readonly IProEventosRepository _eventoRepository;

  public EventoService(IProEventosGeneric genericRepository, IProEventosRepository eventoRepository)
  {
    _genericRepository = genericRepository;
    _eventoRepository = eventoRepository;
  }

  public async Task<Evento> AddEventos(Evento model)
  {
    try
    {
      _genericRepository.Add(model); // Ja pega o tipo do model passado automaticamente

      bool save = await _genericRepository.SaveChangesAsync();

      if(save)
      {
        return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
      }

      return null;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Evento> UpdateEvento(int eventoId, Evento model)
  {
    try
    {
      var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false); // busca um evento especifico

      model.Id = evento.Id;

      // verificaçao se um evento foi retornado ou nao
      if (evento == null)
      {
        return null;
      }

      _genericRepository.Uptate(model);

      // se foi salvo
      bool save = await _genericRepository.SaveChangesAsync();

      if(save)
      {
        return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
      }

      return null;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<bool> DeleteEvento(int eventoId)
  {
    try
    {
      var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);

      // se o evento nao for encontrado para ser excluido
      if (evento == null)
      {
        throw new Exception("Evento não foi encontrado para ser excluido.");
      }

      _genericRepository.Delete(evento);

      return await _genericRepository.SaveChangesAsync();
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
  {
    try
    {
      var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);

      if(eventos == null) 
      {
        return null;
      }
        
      return eventos;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
  {
    try
    {
      var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);

      if(eventos == null)
      {
        return null;
      }

      return eventos;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
  {
    try
    {
      var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);

      if(evento == null)
      {
        return null;
      }

      return evento;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
