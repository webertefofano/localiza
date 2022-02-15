USE [master]
GO
/****** Object:  Database [localiza]    Script Date: 15/02/2022 00:39:06 ******/
CREATE DATABASE [localiza]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'localiza', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\localiza.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'localiza_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\localiza_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [localiza] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [localiza].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [localiza] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [localiza] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [localiza] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [localiza] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [localiza] SET ARITHABORT OFF 
GO
ALTER DATABASE [localiza] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [localiza] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [localiza] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [localiza] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [localiza] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [localiza] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [localiza] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [localiza] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [localiza] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [localiza] SET  DISABLE_BROKER 
GO
ALTER DATABASE [localiza] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [localiza] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [localiza] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [localiza] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [localiza] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [localiza] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [localiza] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [localiza] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [localiza] SET  MULTI_USER 
GO
ALTER DATABASE [localiza] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [localiza] SET DB_CHAINING OFF 
GO
ALTER DATABASE [localiza] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [localiza] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [localiza] SET DELAYED_DURABILITY = DISABLED 
GO
USE [localiza]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[ID_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NOT NULL,
	[CPF] [bigint] NOT NULL,
	[DATA_NACIMENTO] [datetimeoffset](7) NOT NULL,
	[NUMERO_CNH] [bigint] NOT NULL,
	[ENDERECO] [varchar](50) NULL,
	[NUMERO] [nchar](10) NULL,
	[BAIRRO] [varchar](50) NULL,
	[CIDADE] [varchar](100) NULL,
	[ESTADO] [char](2) NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[ID_CLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FABRICANTE]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FABRICANTE](
	[ID_FABRICANTE] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](50) NOT NULL,
	[PESO] [int] NULL,
 CONSTRAINT [PK_FABRICANTE] PRIMARY KEY CLUSTERED 
(
	[ID_FABRICANTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG](
	[ID_LOG] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [uniqueidentifier] NULL,
	[MENSAGENS] [varchar](4000) NULL,
	[ERRO] [varchar](400) NULL,
	[STATUS_CODE] [int] NULL,
 CONSTRAINT [PK_LOG] PRIMARY KEY CLUSTERED 
(
	[ID_LOG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MODELO]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MODELO](
	[ID_MODELO] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NOT NULL,
	[PESO] [int] NULL,
	[ID_FABRICANTE] [int] NOT NULL,
 CONSTRAINT [PK_MODELO] PRIMARY KEY CLUSTERED 
(
	[ID_MODELO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERMISSAO]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERMISSAO](
	[ID_PERMISSAO] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PERMISSAO] PRIMARY KEY CLUSTERED 
(
	[ID_PERMISSAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RESERVA]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA](
	[ID_RESERVA] [int] IDENTITY(1,1) NOT NULL,
	[DATA] [datetimeoffset](7) NOT NULL,
	[ID_CLIENTE] [int] NOT NULL,
	[ID_VEICULO] [int] NOT NULL,
	[DATA_RETIRADA] [datetimeoffset](7) NOT NULL,
	[DATA_PREVISTA_DEVOLUCAO] [datetimeoffset](7) NULL,
	[DATA_DEVOLUCAO] [datetimeoffset](7) NULL,
	[VEICULO_RETIRADO] [bit] NULL,
 CONSTRAINT [PK_RESERVA] PRIMARY KEY CLUSTERED 
(
	[ID_RESERVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[LOGIN] [varchar](50) NOT NULL,
	[PASSWORD] [varchar](100) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO_PERMISSAO]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO_PERMISSAO](
	[ID_USUARIO_PERMISSAO] [int] IDENTITY(1,1) NOT NULL,
	[ID_USUARIO] [int] NULL,
	[ID_PERMISSAO] [int] NULL,
 CONSTRAINT [PK_USUARIO_PERMISSAO] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO_PERMISSAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VEICULO]    Script Date: 15/02/2022 00:39:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VEICULO](
	[ID_VEICULO] [int] IDENTITY(1,1) NOT NULL,
	[PLACA] [varchar](10) NOT NULL,
	[ID_MODELO] [int] NOT NULL,
	[ANO_FABRICACAO] [int] NULL,
	[ANO_MODELO] [int] NULL,
 CONSTRAINT [PK_VEICULO] PRIMARY KEY CLUSTERED 
(
	[ID_VEICULO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[MODELO]  WITH CHECK ADD  CONSTRAINT [FK_MODELO_FABRICANTE] FOREIGN KEY([ID_FABRICANTE])
REFERENCES [dbo].[FABRICANTE] ([ID_FABRICANTE])
GO
ALTER TABLE [dbo].[MODELO] CHECK CONSTRAINT [FK_MODELO_FABRICANTE]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_CLIENTE] FOREIGN KEY([ID_CLIENTE])
REFERENCES [dbo].[CLIENTE] ([ID_CLIENTE])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK_RESERVA_CLIENTE]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_VEICULO] FOREIGN KEY([ID_VEICULO])
REFERENCES [dbo].[VEICULO] ([ID_VEICULO])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK_RESERVA_VEICULO]
GO
ALTER TABLE [dbo].[USUARIO_PERMISSAO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERMISSAO_PERMISSAO] FOREIGN KEY([ID_PERMISSAO])
REFERENCES [dbo].[PERMISSAO] ([ID_PERMISSAO])
GO
ALTER TABLE [dbo].[USUARIO_PERMISSAO] CHECK CONSTRAINT [FK_USUARIO_PERMISSAO_PERMISSAO]
GO
ALTER TABLE [dbo].[VEICULO]  WITH CHECK ADD  CONSTRAINT [FK_VEICULO_MODELO] FOREIGN KEY([ID_MODELO])
REFERENCES [dbo].[MODELO] ([ID_MODELO])
GO
ALTER TABLE [dbo].[VEICULO] CHECK CONSTRAINT [FK_VEICULO_MODELO]
GO
USE [master]
GO
ALTER DATABASE [localiza] SET  READ_WRITE 
GO
