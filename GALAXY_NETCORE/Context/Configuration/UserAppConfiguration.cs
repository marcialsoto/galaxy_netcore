using System;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GALAXY_NETCORE.Context.Configuration
{
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.HasKey("UserId");
            builder.ToTable("UserApp", "dbo");
        }
    }
}
