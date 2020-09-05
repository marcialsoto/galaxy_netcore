using System;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GALAXY_NETCORE.Context.Configuration
{
    public class TipoArticuloConfiguration : IEntityTypeConfiguration<TipoArticulo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TipoArticulo> builder)
        {
            builder.HasKey("IdTipoArticulo");
            builder.ToTable("TipoArticulo", "dbo");
        }
    }
}
