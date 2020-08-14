using DataLayer.EfCode;
using FeatureAuthorize.PolicyCode;
using JWTIssueExample.ActionFilters;
using JWTIssueExample.Concrete;
using JWTIssueExample.Contracts;
using JWTIssueExample.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JWTIssueExample
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
            services.SetupJwtServices(Configuration);
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            //This registers your database, which now includes the ExtraAuthClasses
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DemoDatabaseConnection")));

            //Register the Permission policy handlers
            services.AddSingleton<IAuthorizationPolicyProvider,
                AuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            // Register action filters
            services.AddScoped<ValidateAccessTokenAttribute>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}