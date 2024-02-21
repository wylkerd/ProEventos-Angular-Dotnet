using ProEventos.Application.Dtos;

namespace ProEventos.Application.Interfaces;

public interface IEventoService
{
  Task<EventoDto> AddEventos(EventoDto model);

  Task<EventoDto> UpdateEvento(int eventoId, EventoDto model);

  Task<bool> DeleteEvento(int eventoId);

  //Eventos
  Task<List<EventoDto>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);

  Task<List<EventoDto>> GetAllEventosAsync(bool includePalestrantes = false);

  Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);
}
