using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

// Contexto para criacao das tabelas no BD
namespace ProEventos.API.Data;
public class DataContext : DbContext
{
  // Passando configs vindas da Startup para o base de DbContext
  public DataContext(DbContextOptions<DataContext> options): base(options) {}
  
  public DbSet<Evento> Eventos { get; set; }
}