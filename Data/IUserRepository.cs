using System;
using workLogger.Models;

namespace workLogger.Data
{
  public interface IUserRepository : IRepository<User>
  {
    bool UserExists(string email);
  }
}
