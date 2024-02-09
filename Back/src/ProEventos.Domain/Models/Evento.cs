namespace ProEventos.Domain.Models;

public class Evento
{
  public int Id { get; set; }
  public string? Local { get; set; }
  public DateTime DataEvento { get; set; }
  public string? Tema { get; set; }
  public int QtdPessoas { get; set; }
  public string? ImagemURL { get; set; }
  public string? Telefone { get; set; }
  public string? Email { get; set; }
  public IEnumerable<Lote>? Lotes { get; set; } // pode possuir VARIOS lotes
  public IEnumerable<RedeSocial>? RedesSociais { get; set; } // pode possuir VARIAS RedesSociais
  
  // Associacao da tabela auxiliar
  public IEnumerable<PalestranteEvento>? PalestrantesEventos { get; set; }
}