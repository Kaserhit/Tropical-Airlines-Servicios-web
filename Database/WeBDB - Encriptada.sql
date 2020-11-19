USE [master]
GO
/****** Object:  Database [WebDB]    Script Date: 19/11/2020 15:41:13 ******/
CREATE DATABASE [WebDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebDB', FILENAME = N'D:\SQLServer\MSSQL15.MSSQLSERVER01\MSSQL\DATA\WebDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebDB_log', FILENAME = N'D:\SQLServer\MSSQL15.MSSQLSERVER01\MSSQL\DATA\WebDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WebDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WebDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebDB] SET RECOVERY FULL 
GO
ALTER DATABASE [WebDB] SET  MULTI_USER 
GO
ALTER DATABASE [WebDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebDB', N'ON'
GO
ALTER DATABASE [WebDB] SET ENCRYPTION ON
GO
ALTER DATABASE [WebDB] SET QUERY_STORE = OFF
GO
USE [WebDB]
GO
/****** Object:  Table [dbo].[Aerolinea]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aerolinea](
	[ALNID] [int] IDENTITY(1,1) NOT NULL,
	[Aerol_Pais] [int] NOT NULL,
	[Consec_Aerol] [int] NOT NULL,
	[Codigo] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Nombre] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Imagen] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AEROL_ALNID] PRIMARY KEY CLUSTERED 
(
	[ALNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aeropuerto]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aeropuerto](
	[APTID] [int] IDENTITY(1,1) NOT NULL,
	[Consec_Aerop] [int] NOT NULL,
	[Cod_Puerta] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Num_Puerta] [int] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Detalle] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
 CONSTRAINT [PK_AEROP_APTID] PRIMARY KEY CLUSTERED 
(
	[APTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[BTCID] [int] IDENTITY(1,1) NOT NULL,
	[Consec_Bitacora] [int] NOT NULL,
	[Usuario_Bitac] [int] NOT NULL,
	[Cod_Registro] [int] NOT NULL,
	[Fecha] [datetime] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Tipo] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Descripcion] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Codigo] [nvarchar](150) NULL,
	[Nombre] [nvarchar](150) NULL,
	[Imagen] [nvarchar](max) NULL,
	[Cod_Puerta] [nvarchar](150) NULL,
	[Num_Puerta] [int] NULL,
	[Detalle] [nvarchar](150) NULL,
	[CSVID] [int] NULL,
	[Consec_Descripcion] [nvarchar](150) NULL,
	[Consecutivo] [nvarchar](150) NULL,
 CONSTRAINT [PK_BITAC_BTCID] PRIMARY KEY CLUSTERED 
(
	[BTCID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[CMPID] [int] IDENTITY(1,1) NOT NULL,
	[Compra_Usuario] [int] NOT NULL,
	[Consec_Compra] [int] NOT NULL,
	[Destino] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Cant_Boletos] [int] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[TotalCompra] [float] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
 CONSTRAINT [PK_COMPRA_CMPID] PRIMARY KEY CLUSTERED 
(
	[CMPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consecutivo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consecutivo](
	[CSVID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Consecutivo] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Prefijo] [nvarchar](5) NULL,
	[RangoInicial] [int] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
	[RangoFinal] [int] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
 CONSTRAINT [PK_CONSEC_CSVID] PRIMARY KEY CLUSTERED 
(
	[CSVID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Error]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Error](
	[ERRID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Mensaje_Error] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
 CONSTRAINT [PK_ERROR_ERRID] PRIMARY KEY CLUSTERED 
(
	[ERRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[PAISID] [int] IDENTITY(1,1) NOT NULL,
	[Consec_Pais] [int] NOT NULL,
	[CodPais] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Nombre] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Imagen] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PAIS_PAISID] PRIMARY KEY CLUSTERED 
(
	[PAISID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva_Boleto]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva_Boleto](
	[RSVID] [int] IDENTITY(1,1) NOT NULL,
	[Reserva_Usuario] [int] NOT NULL,
	[Consec_Reserva] [int] NOT NULL,
	[Destino] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Cant_Boletos] [int] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[TotalCompra] [float] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Num_Reserva] [int] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[BookingID] [nvarchar](7) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
 CONSTRAINT [PK_RESERVA_RSVID] PRIMARY KEY CLUSTERED 
(
	[RSVID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_RESERVA_BOOK] UNIQUE NONCLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ROLID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Rol] [nvarchar](20) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Descripcion] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
 CONSTRAINT [PK_ROL_ROLID] PRIMARY KEY CLUSTERED 
(
	[ROLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Usuario]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Usuario](
	[USRID] [int] NOT NULL,
	[ROLID] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_ROL_USER_ID] PRIMARY KEY CLUSTERED 
(
	[USRID] ASC,
	[ROLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[USRID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
	[Contrasena] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Nombre] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
	[Primer_Apellido] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Segundo_Apellido] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
	[Pregunta] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Respuesta] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Correo] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Administrador] [bit] NULL,
	[Seguridad] [bit] NULL,
	[Consecutivo] [bit] NULL,
	[Mantenimiento] [bit] NULL,
	[Consulta] [bit] NULL,
	[Cliente] [bit] NULL,
 CONSTRAINT [PK_USER_USRID] PRIMARY KEY CLUSTERED 
(
	[USRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[VLOID] [int] IDENTITY(1,1) NOT NULL,
	[Consec_Vuelo] [int] NOT NULL,
	[Vuelo_Aerol] [int] NOT NULL,
	[Vuelo_Aerop] [int] NOT NULL,
	[CodVuelo] [nvarchar](150) NOT NULL,
	[Destino] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Procedencia] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Fecha] [datetime] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Estado_Dest] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Estado_Proced] [nvarchar](150) COLLATE Modern_Spanish_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[Monto] [float] ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
 CONSTRAINT [PK_VUELO_VLOID] PRIMARY KEY CLUSTERED 
(
	[VLOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aerolinea]  WITH CHECK ADD  CONSTRAINT [FK1_AEROL_CONSEC] FOREIGN KEY([Consec_Aerol])
REFERENCES [dbo].[Consecutivo] ([CSVID])
GO
ALTER TABLE [dbo].[Aerolinea] CHECK CONSTRAINT [FK1_AEROL_CONSEC]
GO
ALTER TABLE [dbo].[Aerolinea]  WITH CHECK ADD  CONSTRAINT [FK2_AEROL_PAIS] FOREIGN KEY([Aerol_Pais])
REFERENCES [dbo].[Pais] ([PAISID])
GO
ALTER TABLE [dbo].[Aerolinea] CHECK CONSTRAINT [FK2_AEROL_PAIS]
GO
ALTER TABLE [dbo].[Aeropuerto]  WITH CHECK ADD  CONSTRAINT [FK_AEROP_CONSEC] FOREIGN KEY([Consec_Aerop])
REFERENCES [dbo].[Consecutivo] ([CSVID])
GO
ALTER TABLE [dbo].[Aeropuerto] CHECK CONSTRAINT [FK_AEROP_CONSEC]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_BITAC_USER] FOREIGN KEY([Usuario_Bitac])
REFERENCES [dbo].[Usuario] ([USRID])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_BITAC_USER]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK1_COMPRA_USER] FOREIGN KEY([Compra_Usuario])
REFERENCES [dbo].[Usuario] ([USRID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK1_COMPRA_USER]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK2_COMPRA_CONSEC] FOREIGN KEY([Consec_Compra])
REFERENCES [dbo].[Consecutivo] ([CSVID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK2_COMPRA_CONSEC]
GO
ALTER TABLE [dbo].[Pais]  WITH CHECK ADD  CONSTRAINT [FK_PAIS_CONSEC] FOREIGN KEY([Consec_Pais])
REFERENCES [dbo].[Consecutivo] ([CSVID])
GO
ALTER TABLE [dbo].[Pais] CHECK CONSTRAINT [FK_PAIS_CONSEC]
GO
ALTER TABLE [dbo].[Reserva_Boleto]  WITH CHECK ADD  CONSTRAINT [FK1_RESERVA_USER] FOREIGN KEY([Reserva_Usuario])
REFERENCES [dbo].[Usuario] ([USRID])
GO
ALTER TABLE [dbo].[Reserva_Boleto] CHECK CONSTRAINT [FK1_RESERVA_USER]
GO
ALTER TABLE [dbo].[Reserva_Boleto]  WITH CHECK ADD  CONSTRAINT [FK2_RESERVA_CONSEC] FOREIGN KEY([Consec_Reserva])
REFERENCES [dbo].[Consecutivo] ([CSVID])
GO
ALTER TABLE [dbo].[Reserva_Boleto] CHECK CONSTRAINT [FK2_RESERVA_CONSEC]
GO
ALTER TABLE [dbo].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK1_ROL_USER_USER] FOREIGN KEY([USRID])
REFERENCES [dbo].[Usuario] ([USRID])
GO
ALTER TABLE [dbo].[Rol_Usuario] CHECK CONSTRAINT [FK1_ROL_USER_USER]
GO
ALTER TABLE [dbo].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK2_ROL_USER_ROL] FOREIGN KEY([ROLID])
REFERENCES [dbo].[Rol] ([ROLID])
GO
ALTER TABLE [dbo].[Rol_Usuario] CHECK CONSTRAINT [FK2_ROL_USER_ROL]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK1_VUELO_CONSEC] FOREIGN KEY([Consec_Vuelo])
REFERENCES [dbo].[Consecutivo] ([CSVID])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK1_VUELO_CONSEC]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK2_VUELO_AEROL] FOREIGN KEY([Vuelo_Aerol])
REFERENCES [dbo].[Aerolinea] ([ALNID])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK2_VUELO_AEROL]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK3_VUELO_AEROP] FOREIGN KEY([Vuelo_Aerop])
REFERENCES [dbo].[Aeropuerto] ([APTID])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK3_VUELO_AEROP]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Aerolinea]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Aerolinea](@ALNID int, @Aerol_Pais int, @Consec_Aerol int, @Codigo nvarchar(150), @Nombre nvarchar(150), @Imagen nvarchar(max))

AS  

UPDATE dbo.Aerolinea SET Aerol_Pais = @Aerol_Pais, Consec_Aerol = @Consec_Aerol, Codigo = @Codigo, Nombre = @Nombre, Imagen = @Imagen
WHERE ALNID = @ALNID;  
IF @@rowcount <> 1   
RAISERROR('ID Aerolinea Invalido',16,1) 
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Aeropuerto]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Aeropuerto](@APTID int, @Consec_Aerop int, @Cod_Puerta nvarchar(150), @Num_Puerta int, @Detalle nvarchar(150))  

AS  

UPDATE dbo.Aeropuerto SET Consec_Aerop= @Consec_Aerop, Cod_Puerta = @Cod_Puerta, Num_Puerta = @Num_Puerta, Detalle = @Detalle  
WHERE APTID = @APTID;  
IF @@rowcount <> 1   
RAISERROR('ID Aeropuerto Invalido',16,1) 
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Consecutivo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Consecutivo](@CSVID int, @Descripcion nvarchar(150), @Consecutivo nvarchar(150), @Prefijo nvarchar(150), @RangoInicial int, @RangoFinal int )  

AS  

UPDATE dbo.Consecutivo SET Descripcion = @Descripcion, Consecutivo = @Consecutivo, Prefijo = @Prefijo, RangoInicial = @RangoInicial, RangoFinal = @RangoFinal  
WHERE CSVID = @CSVID;  
IF @@rowcount <> 1   
RAISERROR('ID Consecutivo Invalido',16,1) 
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_contrasena]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_contrasena](@Contrasena nvarchar(150), @newContrasena nvarchar(150))  

AS  

UPDATE dbo.Usuario SET Contrasena = @newContrasena 
WHERE Contrasena = @Contrasena;  
IF @@rowcount <> 1   
RAISERROR('Fallo en la Actualizacion de la contrasena',16,1) 
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Estado_Administrador]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Estado_Administrador](@USRID int, @ROLID int, @Estado bit)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Estado_Clientes]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Estado_Clientes](@USRID int, @ROLID int, @Estado bit)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1)

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Estado_Consecutivo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Estado_Consecutivo](@USRID int, @ROLID int, @Estado bit)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Estado_Consultas]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Estado_Consultas](@USRID int, @ROLID int, @Estado bit)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Estado_Mantenimiento]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Estado_Mantenimiento](@USRID int, @ROLID int, @Estado bit)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Estado_Seguridad]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Estado_Seguridad](@USRID int, @ROLID int, @Estado bit)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Pais]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Pais](@PAISID int, @Consec_Pais bit, @CodPais nvarchar(150), @Nombre nvarchar(150), @Imagen nvarchar(max))  

AS  

update dbo.Pais set Consec_Pais = @Consec_Pais, CodPais = @CodPais, Nombre = @Nombre, Imagen = @Imagen
where PAISID = @PAISID;  
if @@rowcount <> 1   
raiserror('ID Pais Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Rol_Administrador]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Rol_Administrador](@USRID int, @Administrador bit)  

AS  

update dbo.Usuario set Administrador = @Administrador
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Rol_Cliente]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Rol_Cliente](@USRID int, @Cliente bit)  

AS  

update dbo.Usuario set Cliente = @Cliente 
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1)
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Rol_Consecutivo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Rol_Consecutivo](@USRID int, @Consecutivo bit)  

AS  

update dbo.Usuario set Consecutivo = @Consecutivo 
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Rol_Consulta]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Rol_Consulta](@USRID int, @Consulta bit)  

AS  

update dbo.Usuario set Consulta= @Consulta
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Rol_Mantenimiento]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Rol_Mantenimiento](@USRID int, @Mantenimiento bit)  

AS  

update dbo.Usuario set Mantenimiento = @Mantenimiento 
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Actualiza_Rol_Seguridad]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualiza_Rol_Seguridad](@USRID int, @Seguridad bit)  

AS  

update dbo.Usuario set Seguridad = @Seguridad
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Aerolinea]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Aerolinea]
( @ALNID int)

AS

DELETE FROM dbo.Aerolinea WHERE ALNID = @ALNID
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Aeropuerto]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Aeropuerto]
( @APTID int)

AS

DELETE FROM dbo.Aeropuerto WHERE APTID = @APTID
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Consecutivo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Consecutivo]
( @CSVID int)

AS

DELETE FROM dbo.Consecutivo WHERE CSVID = @CSVID
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Pais]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Pais]
( @PAISID int)

 AS

Delete from dbo.Pais where PAISID = @PAISID
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Usuario]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_Usuario]
(@USRID int)

AS

DELETE FROM dbo.Usuario WHERE USRID = @USRID

GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Aerolinea]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Aerolinea]
( @Aerol_Pais int,
  @Consec_Aerol int,
  @Codigo nvarchar(150),
  @Nombre nvarchar(150),
  @Imagen nvarchar(max))

 AS

INSERT INTO dbo.Aerolinea(Aerol_Pais, Consec_Aerol, Codigo, Nombre, Imagen) VALUES (@Aerol_Pais, @Consec_Aerol, @Codigo, @Nombre, @Imagen)
GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Aeropuerto]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Aeropuerto]
( @Consec_Aerop int,
  @Cod_Puerta nvarchar(150),
  @Num_Puerta int,
  @Detalle nvarchar(150))

 AS

INSERT INTO dbo.Aeropuerto(Consec_Aerop, Cod_Puerta, Num_Puerta, Detalle) VALUES (@Consec_Aerop, @Cod_Puerta, @Num_Puerta, @Detalle)
GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Bitacora]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Bitacora]
( @Consec_Bitacora int,
  @Usuario_Bitac int,
  @Cod_Registro int,
  @Fecha datetime,
  @Tipo nvarchar(150),
  @Descripcion nvarchar(150),
  @Codigo nvarchar(150),
  @Nombre nvarchar(150),
  @Imagen nvarchar(MAX),
  @Cod_Puerta nvarchar(150),
  @Num_Puerta int,
  @Detalle nvarchar(150),
  @CSVID int,
  @Consec_Descripcion nvarchar(150),
  @Consecutivo nvarchar(150))

 AS

INSERT INTO dbo.Bitacora(Consec_Bitacora, Usuario_Bitac, Cod_Registro, Fecha, Tipo, Descripcion, Codigo, Nombre, Imagen, Cod_Puerta, Num_Puerta, Detalle, CSVID, Consec_Descripcion, Consecutivo) 
VALUES (@Consec_Bitacora,@Usuario_Bitac, @Cod_Registro, @Fecha,@Tipo,@Descripcion,@Codigo,@Nombre,@Imagen,@Cod_Puerta,@Num_Puerta,@Detalle,@CSVID,@Consec_Descripcion,@Consecutivo)

GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Consecutivo]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Consecutivo]
( @Descripcion nvarchar(150),
  @Consecutivo nvarchar(150),
  @Prefijo nvarchar(150),
  @RangoInicial int,
  @RangoFinal int)

 AS

INSERT INTO dbo.Consecutivo(Descripcion,Consecutivo,Prefijo, RangoInicial, RangoFinal) VALUES (@Descripcion,@Consecutivo,@Prefijo,@RangoInicial,@RangoFinal)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Error]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Error]
( @Fecha datetime,
  @Mensaje_Error nvarchar(150))

AS

INSERT INTO dbo.Error(Fecha, Mensaje_Error) VALUES(@Fecha, @Mensaje_Error)

GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Pais]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Pais]
( @Consec_Pais int,
  @CodPais nvarchar(150),
  @Nombre nvarchar(150),
  @Imagen nvarchar(max))

 AS

Insert into dbo.Pais(Consec_Pais, CodPais, Nombre,Imagen) values(@Consec_Pais, @CodPais, @Nombre,@Imagen)
GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Rol_Usuarios]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Rol_Usuarios]
( @USRID int,
  @ROLID int,
  @Estado bit)

AS

INSERT INTO dbo.Rol_Usuario(USRID, ROLID, Estado) VALUES(@USRID, @ROLID,@Estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_Inserta_Usuario]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Inserta_Usuario]
( @Usuario nvarchar(150),
  @Contrasena nvarchar(150),
  @Nombre nvarchar(150),
  @Primer_Apellido nvarchar(150),
  @Segundo_Apellido nvarchar(150),
  @Pregunta nvarchar(150),
  @Respuesta nvarchar(150),
  @Correo nvarchar(150),
  @Administrador bit,
  @Seguridad bit,
  @Consecutivo bit,
  @Mantenimiento bit,
  @Consulta bit,
  @Cliente bit)

 AS

INSERT INTO dbo.Usuario(Usuario,Contrasena, Nombre, Primer_Apellido,Segundo_Apellido,Pregunta,Respuesta,Correo,Administrador,Seguridad,Consecutivo,Mantenimiento,Consulta,Cliente) VALUES (@Usuario, @Contrasena,@Nombre,@Primer_Apellido,@Segundo_Apellido,@Pregunta,@Respuesta,@Correo,0,0,0,0,0,1)
GO
/****** Object:  StoredProcedure [dbo].[SP_Login_Usuario]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Login_Usuario](@Usuario nvarchar (150), @Contrasena nvarchar (150))  

AS 

Begin

declare @return int;

set @return  = (SELECT COUNT(*) FROM dbo.Usuario  WHERE Usuario = @Usuario  AND Contrasena = @Contrasena);

return @return;

End

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Consec_Aerolinea]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Consec_Aerolinea](@ALNID int)

AS

Select Consec_Aerol from dbo.Aerolinea where ALNID = @ALNID

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Consec_Aeropuerto]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Consec_Aeropuerto](@APTID int)

AS

Select Consec_Aerop from dbo.Aeropuerto where APTID = @APTID

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Consec_ID]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Consec_ID](@CSVID int)

AS

Select CSVID from dbo.Consecutivo where CSVID = @CSVID  

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Consec_Pais]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Consec_Pais](@PAISID int)

AS

Select Consec_Pais from dbo.Pais where PAISID = @PAISID   

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_CSVID_Consecutivos]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_CSVID_Consecutivos]

AS

SELECT TOP 1 CSVID FROM dbo.Consecutivo ORDER BY CSVID DESC

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Filtro_Pais]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Filtro_Pais](@Nombre nvarchar(150))

AS

SELECT PAISID FROM dbo.Pais WHERE Nombre = @Nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Aerolineas]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Aerolineas]

AS

SELECT * FROM dbo.Aerolinea

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Aeropuertos]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Aeropuertos]

AS

SELECT * FROM dbo.Aeropuerto

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Bitacoras]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Bitacoras]

AS

SELECT * FROM dbo.Bitacora

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Consecutivos]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Consecutivos]

AS

SELECT * FROM dbo.Consecutivo

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Errores]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Errores]

AS

SELECT * FROM dbo.Error
GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Paises]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Paises]
AS
SELECT * FROM dbo.Pais

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Rol_Usuarios]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Rol_Usuarios]
AS

SELECT * FROM dbo.Rol_Usuario

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_Info_Usuarios]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_Info_Usuarios]

AS

SELECT * FROM dbo.Usuario

GO
/****** Object:  StoredProcedure [dbo].[SP_Solicitar_USRID_Usuarios]    Script Date: 19/11/2020 15:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Solicitar_USRID_Usuarios]

AS

SELECT TOP 1 USRID FROM dbo.Usuario ORDER BY USRID DESC

GO
USE [master]
GO
ALTER DATABASE [WebDB] SET  READ_WRITE 
GO
