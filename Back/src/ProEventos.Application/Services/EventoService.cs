using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;
using ProEventos.Repository.Interfaces;

namespace ProEventos.Application.Services;

// Camada de Logica de negocio, onde acessa os Repositorios (dados). Determina o comportamento que o Controller tera
// Os DTO`s devem estar apenas na camada Application
public class EventoService : IEventoService
{
  private readonly IProEventosGeneric _genericRepository;
  private readonly IProEventosRepository _eventoRepository;
  private readonly IMapper _mapper;

  public EventoService(IProEventosGeneric genericRepository, IProEventosRepository eventoRepository,
  IMapper mapper)
  {
    _genericRepository = genericRepository;
    _eventoRepository = eventoRepository;
    _mapper = mapper;
  }

  public async Task<EventoDto> AddEventos(EventoDto model)
  {
    try
    {
      var evento = _mapper.Map<Evento>(model);

      _genericRepository.Add<Evento>(evento); // Ja pega o tipo do model passado automaticamente

      bool save = await _genericRepository.SaveChangesAsync();

      if(save)
      {
        var eventoCriadoRetorno = await _eventoRepository.GetEventoByIdAsync(evento.Id, false);;
        return _mapper.Map<EventoDto>(eventoCriadoRetorno);
      }

      return null;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
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

      _mapper.Map(model, evento); // mapeamento de um objeto para o outro

      _genericRepository.Update<Evento>(evento); // evento ja remapeado

      // se foi salvo
      bool save = await _genericRepository.SaveChangesAsync();

      if(save)
      {
        var eventoCriadoRetorno = await _eventoRepository.GetEventoByIdAsync(evento.Id, false);;
        return _mapper.Map<EventoDto>(eventoCriadoRetorno);
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

  public async Task<List<EventoDto>> GetAllEventosAsync(bool includePalestrantes = false)
  {
    try
    {
      var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);

      if(eventos == null) 
      {
        return null;
      }
        
      var resultado = _mapper.Map<List<EventoDto>>(eventos);

      return resultado;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<List<EventoDto>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
  {
    try
    {
      var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);

      if(eventos == null)
      {
        return null;
      }

      var resultado = _mapper.Map<List<EventoDto>>(eventos);

      return resultado;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
  {
    try
    {
      var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);

      if(evento == null)
      {
        return null;
      }

      var resultado = _mapper.Map<EventoDto>(evento);

      return resultado;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
