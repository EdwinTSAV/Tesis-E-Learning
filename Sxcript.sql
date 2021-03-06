USE [master]
GO
/****** Object:  Database [Oracon]    Script Date: 29/09/2021 21:48:26 ******/
CREATE DATABASE [Oracon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Oracon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Oracon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Oracon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Oracon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Oracon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Oracon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Oracon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Oracon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Oracon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Oracon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Oracon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Oracon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Oracon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Oracon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Oracon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Oracon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Oracon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Oracon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Oracon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Oracon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Oracon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Oracon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Oracon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Oracon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Oracon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Oracon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Oracon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Oracon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Oracon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Oracon] SET  MULTI_USER 
GO
ALTER DATABASE [Oracon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Oracon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Oracon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Oracon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Oracon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Oracon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Oracon] SET QUERY_STORE = OFF
GO
USE [Oracon]
GO
/****** Object:  Table [dbo].[Aprendizaje]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aprendizaje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Aprendizaje] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](25) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cesta]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cesta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NULL,
	[IdCurso] [int] NULL,
	[Pagado] [bit] NULL,
 CONSTRAINT [PK_CursoUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clases]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdModulo] [int] NULL,
	[Nombre] [nvarchar](200) NULL,
	[Video] [nvarchar](500) NULL,
	[Descripcion] [nvarchar](500) NULL,
 CONSTRAINT [PK_Clases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComentarioCurso]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentarioCurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NULL,
	[IdUsuario] [int] NULL,
	[Comentario] [nvarchar](1000) NULL,
 CONSTRAINT [PK_ComentarioCurso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Imagen] [nvarchar](100) NULL,
	[Nombre] [nvarchar](50) NULL,
	[Detalle] [nvarchar](500) NULL,
	[Descripcion] [nvarchar](2500) NULL,
	[Precio] [decimal](18, 2) NULL,
	[IdDocente] [int] NULL,
	[IdCategoria] [int] NULL,
	[Video] [nvarchar](250) NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favoritos]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favoritos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NULL,
	[IdCurso] [int] NULL,
 CONSTRAINT [PK_Favoritos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NULL,
	[Nombre] [nvarchar](200) NULL,
 CONSTRAINT [PK_Seccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recursos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClase] [int] NULL,
	[Archivo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Recursos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requisitos]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requisitos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NULL,
	[Requisito] [nvarchar](500) NULL,
 CONSTRAINT [PK_Requisitos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_DetalleCurso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/09/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Imagen] [nvarchar](100) NULL,
	[Nombres] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](50) NULL,
	[Celular] [nvarchar](12) NULL,
	[Correo] [nvarchar](50) NULL,
	[Username] [nvarchar](10) NULL,
	[Password] [nvarchar](100) NULL,
	[Recovery] [nvarchar](100) NULL,
	[IdRol] [int] NULL,
	[Twitter] [nvarchar](50) NULL,
	[Facebook] [nvarchar](50) NULL,
	[LinkedIn] [nvarchar](50) NULL,
	[YouTube] [nvarchar](50) NULL,
	[Instagram] [nvarchar](50) NULL,
	[Titulo] [nvarchar](75) NULL,
	[Biografia] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Oracon] SET  READ_WRITE 
GO
