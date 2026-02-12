using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreWebApiExample.Models;

public partial class SingleTableContext : DbContext
{
    public SingleTableContext()
    {
    }

    public SingleTableContext(DbContextOptions<SingleTableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoreApiEx> CoreApiExes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            string constring = configuration.GetConnectionString("consettings");
            optionsBuilder.UseSqlServer(constring);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoreApiEx>(entity =>
        {
            entity.HasKey(e => e.ExampleId); // Define primary key

            entity.ToTable("CoreApiEx");

            entity.Property(e => e.ExampleId).HasColumnName("ExampleID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
