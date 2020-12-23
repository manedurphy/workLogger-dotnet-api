using System;
using System.Linq;
using workLogger.Models;

namespace workLogger.Data
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {

    public WorkLoggerContext workLoggerContext
    {
      get { return _context; }
    }

    public UserRepository(WorkLoggerContext context) : base(context)
    {
    }

    public bool UserExists(string email)
    {
      return _context.Users.Where(u => u.Email == email).Any();
    }
  }
}
