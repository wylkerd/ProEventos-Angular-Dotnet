using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Interfaces;
using ProEventos.Application.Dtos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
  private readonly IEventoService _eventoService;

  public EventosController(IEventoService eventoService)
  {
      _eventoService = eventoService;
  }

  // UTILIZAR DAPPER DEPOIS E UTILIZAR DTO DE RETORNO DIRETAMENTE, SEM AUTOMAPPER
  [HttpGet]
  public async Task<IActionResult> GetAllEventos() // IActionResult permite devolver o codigo HTTP
  {
    try
    {
      var eventos = await _eventoService.GetAllEventosAsync(true); // true pra poder retornar os palestrantes
      if (eventos == null) return NoContent();

      return Ok(eventos);
    }
    catch(Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      var evento = await _eventoService.GetEventosByIdAsync(id, true);
      if(evento == null) return NoContent();

      return Ok(evento);
    }
    catch(Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
    }
  }

  [HttpGet("tema/{tema}")]
  public async Task<IActionResult> GetByTema(string tema)
  {
    try
    {
      var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);

      if(eventos == null) return NoContent();

      return Ok(eventos);
    }
    catch(Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
    }
  }

  [HttpPost]
  public async Task<IActionResult> Post(EventoDto model)
  {
    try
    {
      var evento = await _eventoService.AddEventos(model);

      if(evento == null) return NoContent();

      return Created($"/api/eventos/{model.Id}", evento);
    }
    catch(Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir eventos. Erro: {ex.Message}");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, EventoDto model)
  {
    try
    {
      var evento = await _eventoService.UpdateEvento(id, model);
      if(evento == null) return NoContent();

      return Ok(evento);
    }
    catch (Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      var evento = await _eventoService.GetEventosByIdAsync(id, true);
      if(evento == null) return NoContent();

      return await _eventoService.DeleteEvento(id) ?
        Ok(new { message = $"Evento Deletado com sucesso."}) 
        : throw new Exception("Ocorreu um problema nao especifico ao tentar deletar o Evento.");
    
    }
    catch(Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
    }
  }

}
