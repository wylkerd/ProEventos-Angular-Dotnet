namespace ProEventos.Domain.Models;

// TABELA AUXILIAR (muitos pra muitos)
public class PalestranteEvento
{
  public int PalestranteId { get; set; }

  public Palestrante? Palestrante { get; set; }

  public int EventoId { get; set; }

  public Evento? Evento { get; set; }    
}