USE [master]
GO
/****** Object:  Database [GamaFac]    Script Date: 29/11/2021 22:14:18 ******/
CREATE DATABASE [GamaFac]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SIN_BD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SIN_BD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SIN_BD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SIN_BD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GamaFac] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GamaFac].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GamaFac] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GamaFac] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GamaFac] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GamaFac] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GamaFac] SET ARITHABORT OFF 
GO
ALTER DATABASE [GamaFac] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GamaFac] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GamaFac] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GamaFac] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GamaFac] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GamaFac] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GamaFac] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GamaFac] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GamaFac] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GamaFac] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GamaFac] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GamaFac] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GamaFac] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GamaFac] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GamaFac] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GamaFac] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GamaFac] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GamaFac] SET RECOVERY FULL 
GO
ALTER DATABASE [GamaFac] SET  MULTI_USER 
GO
ALTER DATABASE [GamaFac] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GamaFac] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GamaFac] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GamaFac] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GamaFac] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GamaFac] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GamaFac', N'ON'
GO
ALTER DATABASE [GamaFac] SET QUERY_STORE = OFF
GO
USE [GamaFac]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[IdActividad] [int] NOT NULL,
	[CodigoCAEB] [varchar](50) NULL,
	[Nombre] [nchar](10) NULL,
 CONSTRAINT [PK_Actividad] PRIMARY KEY CLUSTERED 
(
	[IdActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUFD]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUFD](
	[IdCUFD] [bigint] IDENTITY(1,1) NOT NULL,
	[CUFdValue] [varchar](max) NOT NULL,
	[CUIS] [varchar](max) NOT NULL,
	[IdPuntoAtencion] [int] NOT NULL,
	[XMLRequest] [varchar](max) NOT NULL,
	[XMLResponse] [nchar](10) NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_CUFD] PRIMARY KEY CLUSTERED 
(
	[IdCUFD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[IdEmpresa] [int] NOT NULL,
	[NIT] [varchar](50) NULL,
	[Nombre] [varchar](500) NULL,
	[Logo] [varchar](50) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaActividad]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaActividad](
	[IdEmpresaActividad] [nchar](10) NOT NULL,
	[IdEmpresa] [int] NULL,
	[IdActividad] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_EmpresaActividad] PRIMARY KEY CLUSTERED 
(
	[IdEmpresaActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] NOT NULL,
	[IdPuntoAtencion] [int] NULL,
	[nitEmisor] [varchar](50) NOT NULL,
	[razonSocialEmisor] [varchar](50) NULL,
	[cuf] [varchar](50) NULL,
	[cufd] [varchar](50) NULL,
	[fechaFactura] [datetime] NULL,
	[fechaRegistro] [datetime] NULL,
	[codigoCliente] [varchar](50) NULL,
	[montoTotal] [decimal](18, 5) NULL,
	[cafc] [varchar](50) NULL,
	[cabeceraJSON] [varchar](max) NULL,
	[detalleJSON] [varchar](max) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoActividad]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoActividad](
	[IdPuntoActividad] [nchar](10) NOT NULL,
	[IdEmpresaActividad] [int] NULL,
	[IdPuntoAtencion] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_PuntoActividad] PRIMARY KEY CLUSTERED 
(
	[IdPuntoActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoAtencion]    Script Date: 29/11/2021 22:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoAtencion](
	[IdPuntoAtencion] [int] NOT NULL,
	[IdEmpresa] [int] NULL,
	[CUIS] [varchar](50) NULL,
	[NombrePunto] [varchar](50) NULL,
	[TipoSIN] [int] NULL,
	[TipoSINDescripcion] [nchar](10) NULL,
	[IdSucursalSIN] [int] NULL,
	[IdPuntoVentaSIN] [nchar](10) NULL,
 CONSTRAINT [PK_PuntoAtencion] PRIMARY KEY CLUSTERED 
(
	[IdPuntoAtencion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CUFD]  WITH CHECK ADD  CONSTRAINT [FK_CUFD_PuntoAtencion] FOREIGN KEY([IdPuntoAtencion])
REFERENCES [dbo].[PuntoAtencion] ([IdPuntoAtencion])
GO
ALTER TABLE [dbo].[CUFD] CHECK CONSTRAINT [FK_CUFD_PuntoAtencion]
GO
ALTER TABLE [dbo].[EmpresaActividad]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaActividad_Actividad] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividad] ([IdActividad])
GO
ALTER TABLE [dbo].[EmpresaActividad] CHECK CONSTRAINT [FK_EmpresaActividad_Actividad]
GO
ALTER TABLE [dbo].[EmpresaActividad]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaActividad_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO
ALTER TABLE [dbo].[EmpresaActividad] CHECK CONSTRAINT [FK_EmpresaActividad_Empresa]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_PuntoAtencion] FOREIGN KEY([IdPuntoAtencion])
REFERENCES [dbo].[PuntoAtencion] ([IdPuntoAtencion])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_PuntoAtencion]
GO
ALTER TABLE [dbo].[PuntoActividad]  WITH CHECK ADD  CONSTRAINT [FK_PuntoActividad_EmpresaActividad] FOREIGN KEY([IdPuntoActividad])
REFERENCES [dbo].[EmpresaActividad] ([IdEmpresaActividad])
GO
ALTER TABLE [dbo].[PuntoActividad] CHECK CONSTRAINT [FK_PuntoActividad_EmpresaActividad]
GO
ALTER TABLE [dbo].[PuntoActividad]  WITH CHECK ADD  CONSTRAINT [FK_PuntoActividad_PuntoAtencion] FOREIGN KEY([IdPuntoAtencion])
REFERENCES [dbo].[PuntoAtencion] ([IdPuntoAtencion])
GO
ALTER TABLE [dbo].[PuntoActividad] CHECK CONSTRAINT [FK_PuntoActividad_PuntoAtencion]
GO
ALTER TABLE [dbo].[PuntoAtencion]  WITH CHECK ADD  CONSTRAINT [FK_PuntoAtencion_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO
ALTER TABLE [dbo].[PuntoAtencion] CHECK CONSTRAINT [FK_PuntoAtencion_Empresa]
GO
USE [master]
GO
ALTER DATABASE [GamaFac] SET  READ_WRITE 
GO
