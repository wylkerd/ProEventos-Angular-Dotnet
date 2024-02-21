namespace ProEventos.Domain.Models;

// Annotation para definir nome diferente para tabela a ser criada no Banco de Dados
// [Table("Eventos_TB")]
public class Evento
{
  // [Key]
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