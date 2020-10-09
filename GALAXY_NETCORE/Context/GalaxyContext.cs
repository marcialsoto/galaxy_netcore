using System;
using GALAXY_NETCORE.Context.Configuration;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GALAXY_NETCORE.Context
{
    public class GalaxyContext : DbContext
    {
        public GalaxyContext(DbContextOptions<GalaxyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuracion

            modelBuilder.ApplyConfiguration(new TipoArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new ArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new UserAppConfiguration());
            modelBuilder.ApplyConfiguration(new OpcionConfiguration());

            #endregion


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TipoArticulo> TipoArticulos { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
    }
}
