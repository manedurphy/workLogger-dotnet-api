using System;
using System.Collections.Generic;
using System.Linq;

namespace workLogger.Data
{
  public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly WorkLoggerContext _context;
    public BaseRepository(WorkLoggerContext context)
    {
      _context = context;
    }

    public void Add(TEntity entity)
    {
      _context.Add(entity);
      _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
      _context.Set<TEntity>().Remove(entity);
      _context.SaveChanges();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _context.Set<TEntity>().AsEnumerable();
    }

    public TEntity GetById(int id)
    {
      return _context.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
      _context.Set<TEntity>().Update(entity);
      _context.SaveChanges();
    }
  }
}
