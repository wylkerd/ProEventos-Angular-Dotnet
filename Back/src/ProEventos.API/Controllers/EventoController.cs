using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

  public IEnumerable<Evento> _eventos = new Evento[] {
        new Evento{
          EventoId = 1,
          Tema = "Tema teste",
          DataEvento = DateTime.Now.AddDays(2).ToString(),
          Local = "SP",
          Lote = "2",
          QtdPessoas = 250,
          ImagemURL = "foto.png"
        },
        new Evento{
          EventoId = 2,
          Tema = "Tema teste",
          DataEvento = DateTime.Now.AddDays(2).ToString(),
          Local = "SP",
          Lote = "2",
          QtdPessoas = 250,
          ImagemURL = "foto.png"
        }
      };

    public EventoController()
    {

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
      return _eventos.Where(evento => evento.EventoId == id);
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
