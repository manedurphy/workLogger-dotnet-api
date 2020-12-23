using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using workLogger.Data;

namespace workLogger.Models
{
  public static class PrepDB
  {
    public static void PrepPopulation(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        SeedData(serviceScope.ServiceProvider.GetService<WorkLoggerContext>());
      }
    }

    private static void SeedData(WorkLoggerContext workLoggerContext)
    {
      // DEVELOPMENT ONLY
      workLoggerContext.Database.Migrate();
    }
  }
}