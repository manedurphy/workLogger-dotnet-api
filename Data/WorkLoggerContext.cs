using System;
using Microsoft.EntityFrameworkCore;
using workLogger.Models;

namespace workLogger.Data
{
  public class WorkLoggerContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public WorkLoggerContext(DbContextOptions<WorkLoggerContext> options) : base(options)
    {
    }
  }
}
