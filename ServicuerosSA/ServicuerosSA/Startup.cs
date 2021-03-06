﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicuerosSA.Data;
using ServicuerosSA.Models;
using ServicuerosSA.Services;

namespace ServicuerosSA
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(opciones => {
                opciones.Password.RequireDigit = false;
                opciones.Password.RequiredLength = 3;
                opciones.Password.RequiredUniqueChars = 3;
                opciones.Password.RequireLowercase = false;
                opciones.Password.RequireNonAlphanumeric = false;
                opciones.Password.RequireUppercase = false;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CrearRoles(serviceProvider).Wait();

        }
        private async Task CrearRoles(IServiceProvider serviceProvider)
        {
            var roleMagar = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userMagar = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] NombreRoles = { "Admin", "Secre", "Obrero" };
            IdentityResult resultado;
            foreach (var NombreRol in NombreRoles)
            {
                var roleExist = await roleMagar.RoleExistsAsync(NombreRol);
                if (!roleExist)
                {
                    resultado = await roleMagar.CreateAsync(new IdentityRole(NombreRol));
                }
            }
        }
    }
}
