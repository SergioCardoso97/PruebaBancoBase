using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Modelos;

public partial class PruebaBancoBaseContext : DbContext
{
    public PruebaBancoBaseContext()
    {
    }

    public PruebaBancoBaseContext(DbContextOptions<PruebaBancoBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatEstatusPago> CatEstatusPagos { get; set; }

    public virtual DbSet<RelOrdenesProducto> RelOrdenesProductos { get; set; }

    public virtual DbSet<TblCliente> TblClientes { get; set; }

    public virtual DbSet<TblOrdene> TblOrdenes { get; set; }

    public virtual DbSet<TblPago> TblPagos { get; set; }

    public virtual DbSet<TblProducto> TblProductos { get; set; }

    public virtual DbSet<TblVendedore> TblVendedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                              .AddJsonFile("appsettings.json", optional: false).Build();
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BancoBase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatEstatusPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CatEstat__3214EC074015FEBD");

            entity.ToTable("CatEstatusPago");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Estatus)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RelOrdenesProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RelOrden__3214EC07BD05EE74");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTblOrdenesNavigation).WithMany(p => p.RelOrdenesProductos)
                .HasForeignKey(d => d.IdTblOrdenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RelOrdene__IdTbl__3A81B327");

            entity.HasOne(d => d.IdTblProductosNavigation).WithMany(p => p.RelOrdenesProductos)
                .HasForeignKey(d => d.IdTblProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RelOrdene__IdTbl__398D8EEE");
        });

        modelBuilder.Entity<TblCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblClien__3214EC07F8823930");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
        });

        modelBuilder.Entity<TblOrdene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblOrden__3214EC070F1C12FB");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTblClienteNavigation).WithMany(p => p.TblOrdenes)
                .HasForeignKey(d => d.IdTblCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblOrdene__IdTbl__34C8D9D1");
        });

        modelBuilder.Entity<TblPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblPagos__3214EC07A386FF38");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Concepto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCatEstatusNavigation).WithMany(p => p.TblPagos)
                .HasForeignKey(d => d.IdCatEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblPagos__IdCatE__4222D4EF");

            entity.HasOne(d => d.IdTblClienteNavigation).WithMany(p => p.TblPagos)
                .HasForeignKey(d => d.IdTblCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblPagos__IdTblC__3F466844");

            entity.HasOne(d => d.IdTblOrdenesNavigation).WithMany(p => p.TblPagos)
                .HasForeignKey(d => d.IdTblOrdenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblPagos__IdTblO__412EB0B6");

            entity.HasOne(d => d.IdTblVendedoresNavigation).WithMany(p => p.TblPagos)
                .HasForeignKey(d => d.IdTblVendedores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblPagos__IdTblV__403A8C7D");
        });

        modelBuilder.Entity<TblProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblProdu__3214EC0739153AE6");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Producto)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTblVendedorNavigation).WithMany(p => p.TblProductos)
                .HasForeignKey(d => d.IdTblVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblProduc__IdTbl__2C3393D0");
        });

        modelBuilder.Entity<TblVendedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblVende__3214EC077328180C");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
