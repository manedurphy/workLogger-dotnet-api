using System.Linq;
using workLogger.Models;

namespace workLogger.Data
{
  public class TaskRepository : BaseRepository<Task>, ITaskRepository

  {
    public WorkLoggerContext workLoggerContext
    {
      get { return _context; }
    }
    public TaskRepository(WorkLoggerContext context) : base(context)
    {
    }
    public bool TaskExists(long projectNumber)
    {
      return _context.Tasks.Where(t => t.ProjectNumber == projectNumber).Any();
    }

    public bool UserExists(int id)
    {
      return _context.Users.Where(u => u.Id == id).Any();
    }
  }
}