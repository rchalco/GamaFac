using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class DBTintoreriaGamaFacContext : DbContext
    {
        public DBTintoreriaGamaFacContext()
        {
        }

        public DBTintoreriaGamaFacContext(DbContextOptions<DBTintoreriaGamaFacContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dosificacion> Dosificacions { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturasDetalle> FacturasDetalles { get; set; }
        public virtual DbSet<Imagene> Imagenes { get; set; }
        public virtual DbSet<TCaja> TCajas { get; set; }
        public virtual DbSet<TClasificador> TClasificadors { get; set; }
        public virtual DbSet<TClasificadorTipo> TClasificadorTipos { get; set; }
        public virtual DbSet<TClienteFac> TClienteFacs { get; set; }
        public virtual DbSet<TEmpresasSucursale> TEmpresasSucursales { get; set; }
        public virtual DbSet<TOperacionDiariaCaja> TOperacionDiariaCajas { get; set; }
        public virtual DbSet<TParamPrecio> TParamPrecios { get; set; }
        public virtual DbSet<TPedidoDetail> TPedidoDetails { get; set; }
        public virtual DbSet<TPedidoMaster> TPedidoMasters { get; set; }
        public virtual DbSet<TPersona> TPersonas { get; set; }
        public virtual DbSet<TProducto> TProductos { get; set; }
        public virtual DbSet<TRole> TRoles { get; set; }
        public virtual DbSet<TRolesMenu> TRolesMenus { get; set; }
        public virtual DbSet<TSesione> TSesiones { get; set; }
        public virtual DbSet<TUsuario> TUsuarios { get; set; }
        public virtual DbSet<TfacTipoDocumento> TfacTipoDocumentos { get; set; }
        public virtual DbSet<TmenuOpcione> TmenuOpciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=140.82.15.241;Initial Catalog=DBTintoreriaGamaFac;Persist Security Info=True;User ID=sa;Password=mikyches*123;TrustServerCertificate=True");
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBMapParqueos;Persist Security Info=True;User ID=sa;Password=mikyches*123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dosificacion>(entity =>
            {
                entity.HasKey(e => e.IdDosificacion);

                entity.ToTable("Dosificacion", "shFinance");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.LlaveDosificacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NroAutorizacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroFacturaActual).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NumFacturaFin).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NumFacturaInicial).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura", "shFinance");

                entity.Property(e => e.CodControl)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompraVenta)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("descuento");

                entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.FechaUltModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nitcliente).HasColumnName("NITCliente");

                entity.Property(e => e.NombreFactura)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumFactura).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<FacturasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalle)
                    .HasName("PK_FacturaDetalle");

                entity.ToTable("FacturasDetalle", "shFinance");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnType("money");

                entity.Property(e => e.Excento).HasColumnType("money");

                entity.Property(e => e.Ice)
                    .HasColumnType("money")
                    .HasColumnName("ICE");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturasDetalles)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_FacturaDetalle_Factura");
            });

            modelBuilder.Entity<Imagene>(entity =>
            {
                entity.ToTable("imagenes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Img)
                    .HasColumnType("image")
                    .HasColumnName("img");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TCaja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tCajas", "shFinance");

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

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.IdTipoCaja).HasColumnName("idTipoCaja");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<TClasificador>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tClasificador", "shCommon");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciHasta");

                entity.Property(e => e.IdClasificador).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TClasificadorTipo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tClasificadorTipo", "shCommon");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciHasta");

                entity.Property(e => e.IdClasificadorTipo).ValueGeneratedOnAdd();

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TClienteFac>(entity =>
            {
                entity.HasKey(e => e.IdclienteFac);

                entity.ToTable("tClienteFac", "shfactura");

                entity.Property(e => e.IdclienteFac).HasColumnName("idclienteFac");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Extension)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistroHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistroHasta");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumCelular)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numCelular");
            });

            modelBuilder.Entity<TEmpresasSucursale>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tEmpresasSucursales", "shSecurity");

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

                entity.Property(e => e.IdEmpresa)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEmpresa");

                entity.Property(e => e.IdEmpresaPadre).HasColumnName("idEmpresaPadre");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

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

                entity.Property(e => e.ResponsableLegal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

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

                entity.ToTable("tOperacionDiariaCaja", "shFinance");

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

                entity.ToTable("tParamPrecios", "shBusiness");

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

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.PicProducto).HasColumnName("picProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precioUnitario");
            });

            modelBuilder.Entity<TPedidoDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tPedidoDetail", "shBusiness");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdPedDetail)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPedDetail");

                entity.Property(e => e.IdPedMaster).HasColumnName("idPedMaster");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<TPedidoMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tPedidoMaster", "shBusiness");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEntrega");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.IdAmbiente).HasColumnName("idAmbiente");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdFacCliente).HasColumnName("idFacCliente");

                entity.Property(e => e.IdFacTipoPago).HasColumnName("idFacTipoPago");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.IdOperacionDiariaCaja).HasColumnName("idOperacionDiariaCaja");

                entity.Property(e => e.IdPedMaster)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPedMaster");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.MontoDescuento).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MontoEntrada).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MontoSalida).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TPersona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("tPersonas", "shSecurity");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

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

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("tProductos", "shBusiness");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoProducto");

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

                entity.Property(e => e.IdClasificador).HasColumnName("idClasificador");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Idsesion).HasColumnName("idsesion");

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

                entity.Property(e => e.UnidadDeMedida)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tRoles", "shSecurity");

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

                entity.Property(e => e.IdSesion).HasColumnName("id_sesion");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<TRolesMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tRolesMenu", "shCommon");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdMenuOpcion).HasColumnName("idMenuOpcion");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdrolMenu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idrolMenu");
            });

            modelBuilder.Entity<TSesione>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tSesiones", "shSecurity");

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

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("tUsuarios", "shSecurity");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

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

            modelBuilder.Entity<TfacTipoDocumento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tfacTipoDocumento", "shFinance");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciHasta");

                entity.Property(e => e.IdSesion).HasColumnName("idSesion");

                entity.Property(e => e.IdfactipoDocumento)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idfactipoDocumento");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipoDocumento");
            });

            modelBuilder.Entity<TmenuOpcione>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmenuOpciones", "shCommon");

                entity.Property(e => e.Decripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.FechaVigenciaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVigenciaHasta");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("icon");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdMenuOpcion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idMenuOpcion");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
