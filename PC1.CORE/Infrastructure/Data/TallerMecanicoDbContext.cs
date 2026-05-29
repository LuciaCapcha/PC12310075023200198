using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PC1.CORE.Core.Entities;

namespace PC1.CORE.Infrastructure.Data;

public partial class TallerMecanicoDbContext : DbContext
{
    public TallerMecanicoDbContext()
    {
    }

    public TallerMecanicoDbContext(DbContextOptions<TallerMecanicoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<OrdenServicio> OrdenServicios { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TallerMecanicoDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83FD49132C4");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Correo, "UQ__Cliente__2A586E0BA4C6C121").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Materno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("materno");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Paterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paterno");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<OrdenServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenSer__3213E83FBA803BB4");

            entity.ToTable("OrdenServicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostoEstimado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costoEstimado");
            entity.Property(e => e.DescripcionProblema)
                .HasColumnType("text")
                .HasColumnName("descripcionProblema");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.TipoServicioId).HasColumnName("tipoServicioId");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculoId");

            entity.HasOne(d => d.TipoServicio).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.TipoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenServ__tipoS__300424B4");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__OrdenServ__vehic__2F10007B");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoServ__3213E83F90AABC03");

            entity.ToTable("TipoServicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioBase)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioBase");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3213E83F49C0F750");

            entity.ToTable("Vehiculo");

            entity.HasIndex(e => e.Placa, "UQ__Vehiculo__0C057425C0100469").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("placa");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculo__client__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
