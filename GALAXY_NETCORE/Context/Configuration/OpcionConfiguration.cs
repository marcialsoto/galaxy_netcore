using System;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GALAXY_NETCORE.Context.Configuration
{
    public class OpcionConfiguration : IEntityTypeConfiguration<Opcion>
    {
        public OpcionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Opcion> builder)
        {
            builder.HasKey("IdOpcion");
            builder.ToTable("opcion", "dbo");
        }
    }
}
