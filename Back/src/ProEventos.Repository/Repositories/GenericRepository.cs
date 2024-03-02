using ProEventos.Persistence.Interfaces;

namespace ProEventos.Repository.Repositories;

public class GenericRepository : IProEventosGeneric
{
  private readonly DataContext _context;
        
  public GenericRepository(DataContext context)
  {
    _context = context;
  }
  
  public void Add<T>(T entity) where T : class
  {
    _context.AddAsync(entity);
  }

  public void Update<T>(T entity) where T : class
  {
    _context.Update(entity);
  }

  public void Delete<T>(T entity) where T : class
  {
    _context.Remove(entity);
  }

  public void DeleteRange<T>(T[] entityArray) where T : class
  {
    _context.RemoveRange(entityArray);
  }

  public async Task<bool> SaveChangesAsync()
  {
    bool result = await _context.SaveChangesAsync() > 0;
    return result;
  }
}
