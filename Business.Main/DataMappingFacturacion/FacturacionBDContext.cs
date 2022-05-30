using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Main.DataMappingFacturacion
{
    public partial class FacturacionBDContext : DbContext
    {
        public FacturacionBDContext()
        {
        }

        public FacturacionBDContext(DbContextOptions<FacturacionBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cufd> Cufds { get; set; }
        public virtual DbSet<Cui> Cuis { get; set; }
        public virtual DbSet<EventoSignificativo> EventoSignificativos { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<LogProcesoMasivo> LogProcesoMasivos { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=140.82.15.241;Initial Catalog=FacturacionBD;Persist Security Info=True;User ID=sa;Password=mikyches*123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cufd>(entity =>
            {
                entity.HasKey(e => e.IdCufd)
                    .HasName("PK_CufdPROD");

                entity.ToTable("CUFD");

                entity.Property(e => e.CodigoControl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CuisRequest)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Response)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ValorCufd)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCuisNavigation)
                    .WithMany(p => p.Cufds)
                    .HasForeignKey(d => d.IdCuis)
                    .HasConstraintName("FK_CUFD_CUIS");

                entity.HasOne(d => d.IdOfficeNavigation)
                    .WithMany(p => p.Cufds)
                    .HasForeignKey(d => d.IdOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUFD_Office");
            });

            modelBuilder.Entity<Cui>(entity =>
            {
                entity.HasKey(e => e.IdCuis)
                    .HasName("PK_CuisPROD");

                entity.ToTable("CUIS");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.IdOfficeMf).HasColumnName("IdOfficeMF");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Response)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ValorCuis)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOfficeNavigation)
                    .WithMany(p => p.Cuis)
                    .HasForeignKey(d => d.IdOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUIS_Office");
            });

            modelBuilder.Entity<EventoSignificativo>(entity =>
            {
                entity.HasKey(e => e.IdEventoSignificativo);

                entity.ToTable("EventoSignificativo");

                entity.Property(e => e.CodEvento).HasColumnName("codEvento");

                entity.Property(e => e.CodEventoSignificativo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CodigoControlCufd)
                    .IsUnicode(false)
                    .HasColumnName("CodigoControlCUFD");

                entity.Property(e => e.CodigoControlCufdevento)
                    .IsUnicode(false)
                    .HasColumnName("CodigoControlCUFDEvento");

                entity.Property(e => e.CufdEvento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionEvento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraIni).HasColumnType("datetime");

                entity.Property(e => e.Idcufd).HasColumnName("IDCUFD");

                entity.Property(e => e.Idcufdevento).HasColumnName("IDCUFDEVENTO");

                entity.Property(e => e.XmlRequest)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.XmlResponse)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOfficeNavigation)
                    .WithMany(p => p.EventoSignificativos)
                    .HasForeignKey(d => d.IdOffice)
                    .HasConstraintName("FK_EventoSignificativo_Office");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice)
                    .HasName("PK_InvoiceImportPROD");

                entity.ToTable("Invoice");

                entity.Property(e => e.CodeBatch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DetailProcess)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FileNameCompress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FolderContainer)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdEvent)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Invoice1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Invoice");

                entity.Property(e => e.InvoiceNumber).IsUnicode(false);

                entity.Property(e => e.InvoiceSign).IsUnicode(false);

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessObject).IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCufdNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdCufd)
                    .HasConstraintName("FK_Invoice_CUFD");

                entity.HasOne(d => d.IdOfficeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdOffice)
                    .HasConstraintName("FK_Invoice_Office");
            });

            modelBuilder.Entity<LogProcesoMasivo>(entity =>
            {
                entity.HasKey(e => e.IdLogProcesoMasivo)
                    .HasName("PK_LogProcesoMasivoPROD");

                entity.ToTable("LogProcesoMasivo");

                entity.Property(e => e.CodeBatch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoDescripcionEnviado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoDescripcionValidado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecepcionEnviado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecepcionEnviadoValidado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoEnviado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoValidado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.XmlrequestEnviado)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("XMLRequestEnviado");

                entity.Property(e => e.XmlrequestValidado)
                    .IsUnicode(false)
                    .HasColumnName("XMLRequestValidado");

                entity.Property(e => e.XmlresponseEnviado)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("XMLResponseEnviado");

                entity.Property(e => e.XmlresponseValidado)
                    .IsUnicode(false)
                    .HasColumnName("XMLResponseValidado");

                entity.HasOne(d => d.IdEventoSignificativoNavigation)
                    .WithMany(p => p.LogProcesoMasivos)
                    .HasForeignKey(d => d.IdEventoSignificativo)
                    .HasConstraintName("FK_LogProcesoMasivo_EventoSignificativo");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.IdOffice)
                    .HasName("PK_OfficeSIN");

                entity.ToTable("Office");

                entity.Property(e => e.IdOffice).ValueGeneratedNever();

                entity.Property(e => e.CodigoSistema)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoPuntoVenta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CuisCreacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdPuntoVentaSin).HasColumnName("IdPuntoVentaSIN");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NIT");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.HasKey(e => e.IdParameter)
                    .HasName("PK_ParameterSIN");

                entity.ToTable("Parameter");

                entity.Property(e => e.IdParameter).ValueGeneratedNever();

                entity.Property(e => e.DateRegister).HasColumnType("datetime");

                entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
