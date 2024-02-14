using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Repository.Mappings;

// Contexto para criacao das tabelas no BD
namespace ProEventos.Repository;
public class DataContext : DbContext
{
  // Passando configs vindas da Startup para o base de DbContext
  public DataContext(DbContextOptions<DataContext> options): base(options) {}
  
  // Tabelas
  public virtual DbSet<Evento>? Eventos { get; set; }
  public virtual DbSet<Lote>? Lotes { get; set; }
  public virtual DbSet<Palestrante>? Palestrantes { get; set; }
  public virtual DbSet<PalestranteEvento>? PalestrantesEventos { get; set; }
  public virtual DbSet<RedeSocial>? RedesSociais { get; set; }


  // Mappings de relacionamento entre entidades
  protected override void OnModelCreating(ModelBuilder builder)
  {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new EventoMap());
      builder.ApplyConfiguration(new PalestranteEventoMap());
      builder.ApplyConfiguration(new PalestranteMap());
      builder.ApplyConfiguration(new LoteMap());
      builder.ApplyConfiguration(new RedeSocialMap());
  }
}