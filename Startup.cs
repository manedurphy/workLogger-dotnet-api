using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using workLogger.Data;
using Microsoft.EntityFrameworkCore;
using workLogger.Models;

namespace workLogger
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddDbContext<WorkLoggerContext>(options => options.UseMySQL(Environment.GetEnvironmentVariable("MYSQL_CONNECTION")));
      services.AddAutoMapper(typeof(Startup));
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ITaskRepository, TaskRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WorkLoggerContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        PrepDB.PrepPopulation(app);
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
