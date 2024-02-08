using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
  private readonly DataContext _context;

  public EventosController(DataContext context)
  {
    _context = context;
  }

  [HttpGet]
  public IEnumerable<Evento> Get()
  {
    return _context.Eventos;
  }

  [HttpGet("{id}")]
  public Evento GetById(int id)
  {
    return _context.Eventos.FirstOrDefault(
      evento => evento.EventoId == id
    );
  }

  [HttpGet("EventosInCity")]
  public IQueryable<Evento> GetEventoInCity()
  {
    return _context.Eventos
      .FromSqlRaw($"select * from Eventos e where e.Local like '%city';");
  }

  [HttpPost]
  public string Post()
  {
    return "Exemplo de Post";
  }

  [HttpPut("{id}")]
  public string Put(int id)
  {
      return $"Exemplo de Put com id = {id}";
  }

  [HttpDelete("{id}")]
  public string Delete(int id)
  {
      return $"Exemplo de Delete com id = {id}";
  }

}
