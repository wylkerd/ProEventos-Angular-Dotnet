namespace ProEventos.Domain.Models;

// TABELA AUXILIAR (muitos pra muitos)
public class PalestranteEvento
{
  public int PalestranteId { get; set; } //FK

  public Palestrante? Palestrante { get; set; }

  public int EventoId { get; set; } //FK

  public Evento? Evento { get; set; }    
}