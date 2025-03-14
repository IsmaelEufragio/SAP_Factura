﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using FacturasSAP.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacturasSAP.DatAccess.Context;

public partial class HCFContext : DbContext
{
    public HCFContext()
    {
    }

    public HCFContext(DbContextOptions<HCFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tbEmpresaGuium> tbEmpresaGuia { get; set; }

    public virtual DbSet<tbPagoEncomiendaDetalle> tbPagoEncomiendaDetalles { get; set; }

    public virtual DbSet<tbPagoEncomiendum> tbPagoEncomienda { get; set; }

    public virtual DbSet<tbTipoEncomiendum> tbTipoEncomienda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=HCF;User ID=sa;Password=Josue.Eufragio2001", x => x.UseDateOnlyTimeOnly());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tbEmpresaGuium>(entity =>
        {
            entity.HasKey(e => e.IdEmpresaGuia).HasName("PK_tbEmpresaGuia_IdEmpresaGuia");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(300);
            entity.Property(e => e.Exprecion).HasMaxLength(300);
        });

        modelBuilder.Entity<tbPagoEncomiendaDetalle>(entity =>
        {
            entity.HasKey(e => e.IdPagoEncomiendaDetalle).HasName("PK_tbPagoEncomiendaDetalle_IdPagoEncomiendaDetalle");

            entity.ToTable("tbPagoEncomiendaDetalle");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Traking).HasMaxLength(50);

            entity.HasOne(d => d.IdPagoEncomiendaNavigation).WithMany(p => p.tbPagoEncomiendaDetalles)
                .HasForeignKey(d => d.IdPagoEncomienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbPagoEncomiendaDetalle_IdPagoEncomienda_IdPagoEncomienda");

            entity.HasOne(d => d.IdTipoEncomiendaNavigation).WithMany(p => p.tbPagoEncomiendaDetalles)
                .HasForeignKey(d => d.IdTipoEncomienda)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<tbPagoEncomiendum>(entity =>
        {
            entity.HasKey(e => e.IdPagoEncomienda).HasName("PK_tbTipoEncomienda_IdPagoEncomienda");

            entity.Property(e => e.Factura).HasMaxLength(50);

            entity.HasOne(d => d.IdEmpresaGuiaNavigation).WithMany(p => p.tbPagoEncomienda)
                .HasForeignKey(d => d.IdEmpresaGuia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbPagoEncomienda_tbTipoUsuario_IdEmpresaGuia");
        });

        modelBuilder.Entity<tbTipoEncomiendum>(entity =>
        {
            entity.HasKey(e => e.IdTipoEncomienda).HasName("PK_tbTipoEncomienda_IdTipoEncomienda");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(300);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}