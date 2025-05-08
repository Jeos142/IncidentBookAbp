using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients;
using IncidentBookAbp.IncidentClassifications;
using IncidentBookAbp.Incidents;
using IncidentBookAbp.Resolutions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace IncidentBookAbp.EntityFrameworkCore
{
    public static class IncidentBookAbpDbContextModelCreatingExtensions
    {
        public static void ConfigureIncidentBookAbp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            // Client
            builder.Entity<Client>(b =>
            {
                b.ToTable("AppClients");
                b.ConfigureByConvention(); // ABP: adds default conventions
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            // IncidentClassification
            builder.Entity<IncidentClassification>(b =>
            {
                b.ToTable("AppIncidentClassifications");
                b.ConfigureByConvention();
                b.Property(x => x.ClassificationName).IsRequired().HasMaxLength(128);
            });

            // Resolution
            builder.Entity<Resolution>(b =>
            {
                b.ToTable("AppResolutions");
                b.ConfigureByConvention();
                b.Property(x => x.ResolutionName).IsRequired().HasMaxLength(128);
            });

            // Incident
            builder.Entity<Incident>(b =>
            {
                b.ToTable("AppIncidents");
                b.ConfigureByConvention();
                b.Property(x => x.Description).IsRequired().HasMaxLength(512);
                b.Property(x => x.DateTime).IsRequired();
                b.Property(x => x.IsComplete).IsRequired();

                // foreign keys
                b.HasOne(x => x.Client)
                    .WithMany()
                    .HasForeignKey(x => x.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Classification)
                    .WithMany()
                    .HasForeignKey(x => x.ClassificationId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Resolution)
                    .WithMany()
                    .HasForeignKey(x => x.ResolutionId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

        }
    }
}
