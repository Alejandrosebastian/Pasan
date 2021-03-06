﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Models;

namespace ServicuerosSA.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<IdentityRole> identityRole { get; set; }
        public DbSet<ServicuerosSA.Models.Bodega> Bodega { get; set; }

        public DbSet<ServicuerosSA.Models.Lote> Lote { get; set; }

        public DbSet<ServicuerosSA.Models.Bodega1> Bodega1 { get; set; }

        public DbSet<ServicuerosSA.Models.Clasificacion> Clasificacion { get; set; }

        public DbSet<ServicuerosSA.Models.Personal> Personal { get; set; }

        public DbSet<ServicuerosSA.Models.Proveedor> Proveedor { get; set; }

        public DbSet<ServicuerosSA.Models.Proveedor_Lote> Proveedor_Lote { get; set; }

        public DbSet<ServicuerosSA.Models.Sexo> Sexo { get; set; }

        public DbSet<ServicuerosSA.Models.TipoBodega> TipoBodega { get; set; }

        public DbSet<ServicuerosSA.Models.TipoPiel> TipoPiel { get; set; }
        public DbSet<ServicuerosSA.Models.Componente> Componente { get; set; }

        public DbSet<ServicuerosSA.Models.Pelambre> Pelambre { get; set; }

        public DbSet<ServicuerosSA.Models.Formula> Formula { get; set; }


        public DbSet<ServicuerosSA.Models.Bombo> Bombo { get; set; }
        public DbSet<ServicuerosSA.Models.Medida> Medida { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ServicuerosSA.Models.Descarne> Descarne { get; set; }
        public DbSet<ServicuerosSA.Models.Bodegatripa> Bodegatripa { get; set; }
        public DbSet<ServicuerosSA.Models.ClasificacionTripa> ClasificacionTripa { get; set; }
        public DbSet<ServicuerosSA.Models.Curtido> Curtido { get; set; }
        public DbSet<ServicuerosSA.Models.Escurrido> Escurrido { get; set; }
        public DbSet<ServicuerosSA.Models.ClasificacionWB> ClasificacionWB { get; set; }
        public DbSet<ServicuerosSA.Models.Clasiweb> ClasificacionesWebblue { get; set; }
        public DbSet<ServicuerosSA.Models.Medido> Medido { get; set; }
        public DbSet<ServicuerosSA.Models.Calibracion> Calibracion { get; set; }
        public DbSet<ServicuerosSA.Models.BodegaCarnaza> BodegaCarnaza { get; set; }
    }

}
