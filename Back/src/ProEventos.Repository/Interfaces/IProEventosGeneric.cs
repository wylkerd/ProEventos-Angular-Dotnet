namespace ProEventos.Persistence.Interfaces;

public interface IProEventosGeneric
{
  // Genéricos
  void Add<T>(T entity) where T: class;

  void Uptate<T>(T entity) where T: class;

  void Delete<T>(T entity) where T: class;

  void DeleteRange<T>(T[] entityArray) where T: class;

  Task<bool> SaveChangesAsync();
}
