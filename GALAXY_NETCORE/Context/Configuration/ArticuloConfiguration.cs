using System;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GALAXY_NETCORE.Context.Configuration
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.HasKey("IdArticulo");
            builder.ToTable("Articulo", "dbo");
            builder.HasOne(d => d.TipoArticulo).WithMany(e => e.Articulos).HasForeignKey(x => x.IdTipoArticulo);
        }
    }
}
