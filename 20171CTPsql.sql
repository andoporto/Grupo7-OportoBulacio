CREATE DATABASE [20171C_TP]
GO

USE [20171C_TP]
GO

ALTER DATABASE [20171C_TP] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [20171C_TP] SET ANSI_NULLS OFF
GO
ALTER DATABASE [20171C_TP] SET ANSI_PADDING OFF
GO
ALTER DATABASE [20171C_TP] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [20171C_TP] SET ARITHABORT OFF
GO
ALTER DATABASE [20171C_TP] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [20171C_TP] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [20171C_TP] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [20171C_TP] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [20171C_TP] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [20171C_TP] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [20171C_TP] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [20171C_TP] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [20171C_TP] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [20171C_TP] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [20171C_TP] SET  DISABLE_BROKER
GO
ALTER DATABASE [20171C_TP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [20171C_TP] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [20171C_TP] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [20171C_TP] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [20171C_TP] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [20171C_TP] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [20171C_TP] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [20171C_TP] SET  READ_WRITE
GO
ALTER DATABASE [20171C_TP] SET RECOVERY FULL
GO
ALTER DATABASE [20171C_TP] SET  MULTI_USER
GO
ALTER DATABASE [20171C_TP] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [20171C_TP] SET DB_CHAINING OFF
GO
USE [20171C_TP]
GO
/****** Object:  Table [dbo].[Versiones]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versiones](
	[IdVersion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Versiones] PRIMARY KEY CLUSTERED 
(
	[IdVersion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumentos]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumentos](
	[IdTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_TiposDocumentos] PRIMARY KEY CLUSTERED 
(
	[IdTipoDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sedes]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sedes](
	[IdSede] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](300) NOT NULL,
	[PrecioGeneral] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Sedes] PRIMARY KEY CLUSTERED 
(
	[IdSede] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[IdCalificacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[IdCalificacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[IdPelicula] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](750) NOT NULL,
	[Imagen] [nvarchar](300) NOT NULL,
	[IdCalificacion] [int] NOT NULL,
	[IdGenero] [int] NOT NULL,
	[Duracion] [int] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[IdPelicula] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carteleras]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carteleras](
	[IdCartelera] [int] IDENTITY(1,1) NOT NULL,
	[IdSede] [int] NOT NULL,
	[IdPelicula] [int] NOT NULL,
	[HoraInicio] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[NumeroSala] [int] NOT NULL,
	[IdVersion] [int] NOT NULL,
	[Lunes] [bit] NOT NULL,
	[Martes] [bit] NOT NULL,
	[Miercoles] [bit] NOT NULL,
	[Jueves] [bit] NOT NULL,
	[Viernes] [bit] NOT NULL,
	[Sabado] [bit] NOT NULL,
	[Domingo] [bit] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
 CONSTRAINT [PK_Carteleras] PRIMARY KEY CLUSTERED 
(
	[IdCartelera] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 05/26/2017 20:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdSede] [int] NOT NULL,
	[IdVersion] [int] NOT NULL,
	[IdPelicula] [int] NOT NULL,
	[FechaHoraInicio] [datetime] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](50) NOT NULL,
	[CantidadEntradas] [int] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Peliculas_Calificaciones]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Calificaciones] FOREIGN KEY([IdCalificacion])
REFERENCES [dbo].[Calificaciones] ([IdCalificacion])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Calificaciones]
GO
/****** Object:  ForeignKey [FK_Peliculas_Generos]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Generos] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Generos] ([IdGenero])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Generos]
GO
/****** Object:  ForeignKey [FK_Carteleras_Peliculas]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Carteleras]  WITH CHECK ADD  CONSTRAINT [FK_Carteleras_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Carteleras] CHECK CONSTRAINT [FK_Carteleras_Peliculas]
GO
/****** Object:  ForeignKey [FK_Carteleras_Sedes]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Carteleras]  WITH CHECK ADD  CONSTRAINT [FK_Carteleras_Sedes] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sedes] ([IdSede])
GO
ALTER TABLE [dbo].[Carteleras] CHECK CONSTRAINT [FK_Carteleras_Sedes]
GO
/****** Object:  ForeignKey [FK_Carteleras_Versiones]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Carteleras]  WITH CHECK ADD  CONSTRAINT [FK_Carteleras_Versiones] FOREIGN KEY([IdVersion])
REFERENCES [dbo].[Versiones] ([IdVersion])
GO
ALTER TABLE [dbo].[Carteleras] CHECK CONSTRAINT [FK_Carteleras_Versiones]
GO
/****** Object:  ForeignKey [FK_Reservas_Peliculas]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Peliculas]
GO
/****** Object:  ForeignKey [FK_Reservas_Sedes]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Sedes] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sedes] ([IdSede])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Sedes]
GO
/****** Object:  ForeignKey [FK_Reservas_TiposDocumentos]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TiposDocumentos] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TiposDocumentos] ([IdTipoDocumento])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TiposDocumentos]
GO
/****** Object:  ForeignKey [FK_Reservas_Versiones]    Script Date: 05/26/2017 20:20:20 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Versiones] FOREIGN KEY([IdVersion])
REFERENCES [dbo].[Versiones] ([IdVersion])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Versiones]
GO
