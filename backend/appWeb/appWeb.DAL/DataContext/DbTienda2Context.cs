using System;
using System.Collections.Generic;
using appWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace appWeb.DAL.DataContext;

public partial class DbTienda2Context : DbContext
{
    public DbTienda2Context()
    {
    }

    public DbTienda2Context(DbContextOptions<DbTienda2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__DC53BE3CAAC1F1D0");

            entity.ToTable("producto");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
