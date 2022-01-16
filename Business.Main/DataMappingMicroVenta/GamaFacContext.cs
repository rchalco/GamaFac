using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Main.DataMappingMicroVenta
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

        public virtual DbSet<TCaja> TCajas { get; set; }
        public virtual DbSet<TCategoria> TCategorias { get; set; }
        public virtual DbSet<TEmpresa> TEmpresas { get; set; }
        public virtual DbSet<TOperacionDiariaCaja> TOperacionDiariaCajas { get; set; }
        public virtual DbSet<TParamPrecio> TParamPrecios { get; set; }
        public virtual DbSet<TProducto> TProductos { get; set; }
        public virtual DbSet<TRole> TRoles { get; set; }
        public virtual DbSet<TSesione> TSesiones { get; set; }
        public virtual DbSet<TStock> TStocks { get; set; }
        public virtual DbSet<TUsuario> TUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=140.82.15.241;Initial Catalog=GamaFac;Persist Security Info=True;User ID=sa;Password=mikyches*123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCaja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tCajas");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdCaja)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCaja");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdTipoCaja).HasColumnName("idTipoCaja");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<TCategoria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tCategorias");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCategoria");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            });

            modelBuilder.Entity<TEmpresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tEmpresa");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.Firma)
                    .IsUnicode(false)
                    .HasColumnName("firma");

                entity.Property(e => e.IdEempresa)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEempresa");

                entity.Property(e => e.IdPadreNb).HasColumnName("idPadre_nb");

                entity.Property(e => e.NitEmpresaVc)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSucursal)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocialVc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("razonSocialVC");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoContribuyente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipoContribuyente");

                entity.Property(e => e.Zona)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOperacionDiariaCaja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tOperacionDiariaCaja");

                entity.Property(e => e.Diferencia)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("diferencia");

                entity.Property(e => e.FechaApertura)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaApertura");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCierre");

                entity.Property(e => e.IdCaja).HasColumnName("idCaja");

                entity.Property(e => e.IdOperacionDiariaCaja)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idOperacionDiariaCaja");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.IdSesionCierre).HasColumnName("idSesionCierre");

                entity.Property(e => e.MontoApertura)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("montoApertura");

                entity.Property(e => e.MontoCierre)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("montoCierre");

                entity.Property(e => e.MontoCierreSis)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("MontoCierreSIS");

                entity.Property(e => e.ObservacioApertura)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("observacioApertura");

                entity.Property(e => e.ObservacionCierre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("observacionCierre");
            });

            modelBuilder.Entity<TParamPrecio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tParamPrecios");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Embase)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("embase");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdPrecio)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPrecio");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<TProducto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tProductos");

                entity.Property(e => e.CajaXunidades).HasColumnName("cajaXunidades");

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idProducto");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Marca)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.PicProducto).HasColumnName("picProducto");
            });

            modelBuilder.Entity<TRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tRoles");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdRol)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idRol");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<TSesione>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tSesiones");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdSesion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSesion");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<TStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tStock");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FechaDeVencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDeVencimiento");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");

                entity.Property(e => e.IdOperacionDiariaCaja).HasColumnName("idOperacionDiariaCaja");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.IdStock)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idStock");

                entity.Property(e => e.PrecioCaja)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precioCaja");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precioUnitario");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tUsuarios");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("celular");

                entity.Property(e => e.DocumentoDeIdentidad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
