namespace ProEventos.Domain.Models;

public class Palestrante
{
  public int Id { get; set; }
  public string? Nome { get; set; }

  public string? MiniCurriculo { get; set; }

  public string? ImagemURL { get; set; }

  public string? Telefone { get; set; }

  public string? Email { get; set; }

  // pode possuir VARIAS redes sociais (um pra muitos)
  public IEnumerable<RedeSocial>? RedesSociais { get; set; } 

  // Associacao da tabela auxiliar (muitos pra muitos)
  public IEnumerable<PalestranteEvento>? PalestrantesEventos { get; set; }
}