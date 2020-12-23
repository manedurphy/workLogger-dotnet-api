using workLogger.Models;

namespace workLogger.Data
{
  public interface ITaskRepository : IRepository<Task>
  {
    bool TaskExists(long projectNumber);
    bool UserExists(int id);
  }
}