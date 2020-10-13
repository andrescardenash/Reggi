using Ibang.Reggi.Application.Contract.IService;
using Ibang.Reggi.Application.Service;
using Ibang.Reggi.Domain.IRepositories;
using Ibang.Reggi.Domain.Models;
using Ibang.Reggi.Infraestructure.Context;
using Ibang.Reggi.Infraestructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Ibang.Reggi.CrossCutting.Register
{
    public static class IoCRegister
    {
        #region Methods
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);

            return services;
        }

        public static void AddConfiguration(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ReggiContext>();
                context.Database.Migrate();
                context.Database.EnsureCreated();
            }
        }
        #endregion

        #region Private Methods
        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            _ = services.AddScoped<ILoginService, LoginService>();
            _ = services.AddScoped<IActivityService, ActivityService>();
            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            _ = services.AddScoped<IUserRepository, UserRepository>();
            _ = services.AddScoped<IActivityRepository, ActivityRepository>();

            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            _ = services.AddDbContext<ReggiContext>(options => options.UseSqlServer(configuration.GetConnectionString("ReggiConnection")));
            _ = services.AddIdentityCore<User>()
                              .AddRoles<IdentityRole>()
                              .AddEntityFrameworkStores<ReggiContext>()
                              .AddDefaultTokenProviders()
                              .AddSignInManager<SignInManager<User>>()
                              .AddUserManager<UserManager<User>>();
            _ = services.Configure<IdentityOptions>(options =>
                                    {
                                        options.Password.RequireDigit = false;
                                        options.Password.RequiredLength = 1;
                                        options.Password.RequireLowercase = false;
                                        options.Password.RequireNonAlphanumeric = false;
                                        options.Password.RequireUppercase = false;
                                    });
            _ = services.AddAuthorization(authorization =>
                                    {
                                        authorization.AddPolicy(JwtBearerDefaults.AuthenticationScheme, 
                                        policy => policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser());
                                    });
            _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                              .AddCookie(IdentityConstants.ApplicationScheme)
                              .AddJwtBearer(options =>
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = false,
                                        ValidateAudience = false,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        IssuerSigningKey = new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes(configuration["JWT:key"])),
                                        ClockSkew = TimeSpan.Zero
                                    });
            _ = services.AddMvc();
            return services;
        }
        #endregion
    }
}
