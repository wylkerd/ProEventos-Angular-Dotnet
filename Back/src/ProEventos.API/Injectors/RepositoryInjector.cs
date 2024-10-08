using ProEventos.Application.Interfaces;
using ProEventos.Application.Services;
using ProEventos.Persistence.Interfaces;
using ProEventos.Repository.Interfaces;
using ProEventos.Repository.Repositories;

namespace ProEventos.API.Injectors;

public class RepositoryInjector
{
  public static void RegisterRepositories(IServiceCollection services)
  {
    services.AddScoped<IEventoService, EventoService>();
    services.AddScoped<ILoteService, LoteService>();

    services.AddScoped<IProEventosGeneric, GenericRepository>();
    services.AddScoped<IProEventosRepository, EventoRepository>();
    services.AddScoped<ILoteRepository, LoteRepository>();
  }
}
