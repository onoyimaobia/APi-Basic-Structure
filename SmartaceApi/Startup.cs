
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smartace.Application;
using Smartace.Core.Data;
using SmartaceApi.ModelHelper;
using SmartaceApi.ModelHelper.BackGroundService;
using System.Reflection;

namespace SmartaceApi
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
            services.ConfigureSwagger();
            services.ConfigureAuthentication(Configuration);
            services.AddControllers();
            services.AddTransient<ITokenGenerator, JWTTokenGenerator>();
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("SmartaceDb")));
            services.AddHangfireServer();
            services.AddControllers();
            services.AddDbContext<SmartaceContext>(options =>
                                                   options.UseSqlServer(Configuration.GetConnectionString("SmartaceDb"), b => b.MigrationsAssembly("Smartace.Core")));
            


            AppBootstraper.InitServices(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestService");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHangfireDashboard("/hangfire", new DashboardOptions { 
            Authorization = new[] {new HangfireDashboardAuthorizationFilter()}
            });
        }
    }
}
