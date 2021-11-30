using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Main.DataMapping
{
    public partial class GamaFacContext : DbContext
    {
        public GamaFacContext()
        {
        }

        public GamaFacContext(DbContextOptions<GamaFacContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividads { get; set; }
        public virtual DbSet<Cufd> Cufds { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<EmpresaActividad> EmpresaActividads { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<PuntoActividad> PuntoActividads { get; set; }
        public virtual DbSet<PuntoAtencion> PuntoAtencions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=GamaFac;Persist Security Info=True;User ID=sa;Password=admin.123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.IdActividad);

                entity.ToTable("Actividad");

                entity.Property(e => e.IdActividad).ValueGeneratedNever();

                entity.Property(e => e.CodigoCaeb)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CodigoCAEB");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cufd>(entity =>
            {
                entity.HasKey(e => e.IdCufd);

                entity.ToTable("CUFD");

                entity.Property(e => e.IdCufd).HasColumnName("IdCUFD");

                entity.Property(e => e.CufdValue)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("CUFdValue");

                entity.Property(e => e.Cuis)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("CUIS");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Xmlrequest)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("XMLRequest");

                entity.Property(e => e.Xmlresponse)
                    .HasMaxLength(10)
                    .HasColumnName("XMLResponse")
                    .IsFixedLength();

                entity.HasOne(d => d.IdPuntoAtencionNavigation)
                    .WithMany(p => p.Cufds)
                    .HasForeignKey(d => d.IdPuntoAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUFD_PuntoAtencion");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.ToTable("Empresa");

                entity.Property(e => e.IdEmpresa).ValueGeneratedNever();

                entity.Property(e => e.Logo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NIT");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpresaActividad>(entity =>
            {
                entity.HasKey(e => e.IdEmpresaActividad);

                entity.ToTable("EmpresaActividad");

                entity.Property(e => e.IdEmpresaActividad)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.EmpresaActividads)
                    .HasForeignKey(d => d.IdActividad)
                    .HasConstraintName("FK_EmpresaActividad_Actividad");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EmpresaActividads)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_EmpresaActividad_Empresa");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura).ValueGeneratedNever();

                entity.Property(e => e.CabeceraJson)
                    .IsUnicode(false)
                    .HasColumnName("cabeceraJSON");

                entity.Property(e => e.Cafc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cafc");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoCliente");

                entity.Property(e => e.Cuf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cuf");

                entity.Property(e => e.Cufd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cufd");

                entity.Property(e => e.DetalleJson)
                    .IsUnicode(false)
                    .HasColumnName("detalleJSON");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFactura");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.MontoTotal)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("montoTotal");

                entity.Property(e => e.NitEmisor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nitEmisor");

                entity.Property(e => e.RazonSocialEmisor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("razonSocialEmisor");

                entity.HasOne(d => d.IdPuntoAtencionNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdPuntoAtencion)
                    .HasConstraintName("FK_Factura_PuntoAtencion");
            });

            modelBuilder.Entity<PuntoActividad>(entity =>
            {
                entity.HasKey(e => e.IdPuntoActividad);

                entity.ToTable("PuntoActividad");

                entity.Property(e => e.IdPuntoActividad)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdPuntoActividadNavigation)
                    .WithOne(p => p.PuntoActividad)
                    .HasForeignKey<PuntoActividad>(d => d.IdPuntoActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoActividad_EmpresaActividad");

                entity.HasOne(d => d.IdPuntoAtencionNavigation)
                    .WithMany(p => p.PuntoActividads)
                    .HasForeignKey(d => d.IdPuntoAtencion)
                    .HasConstraintName("FK_PuntoActividad_PuntoAtencion");
            });

            modelBuilder.Entity<PuntoAtencion>(entity =>
            {
                entity.HasKey(e => e.IdPuntoAtencion);

                entity.ToTable("PuntoAtencion");

                entity.Property(e => e.IdPuntoAtencion).ValueGeneratedNever();

                entity.Property(e => e.Cuis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUIS");

                entity.Property(e => e.IdPuntoVentaSin)
                    .HasMaxLength(10)
                    .HasColumnName("IdPuntoVentaSIN")
                    .IsFixedLength();

                entity.Property(e => e.IdSucursalSin).HasColumnName("IdSucursalSIN");

                entity.Property(e => e.NombrePunto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSin).HasColumnName("TipoSIN");

                entity.Property(e => e.TipoSindescripcion)
                    .HasMaxLength(10)
                    .HasColumnName("TipoSINDescripcion")
                    .IsFixedLength();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PuntoAtencions)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_PuntoAtencion_Empresa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
