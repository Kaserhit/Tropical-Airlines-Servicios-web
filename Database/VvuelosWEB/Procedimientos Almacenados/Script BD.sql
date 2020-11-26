USE [MASTER]	
GO

IF ( EXISTS ( SELECT * FROM SYSDATABASES WHERE name = 'WebDBTransac'))
	BEGIN TRY  
		PRINT ' - Eliminando BD previa -  '
		DROP DATABASE WebDBTransac -- Si existe la elimino
	END TRY  
	BEGIN CATCH  
		-- Detalles del error --code to run if error occurs
		PRINT ' - La BD no se pudo eliminar, detalles...'
		PRINT '		Error Number    : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_NUMBER()), ' - ')
		PRINT '		Error State     : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_STATE()), ' - ')
		PRINT '		Error Severity  : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_SEVERITY()), ' - ')
		print '		Error Procedure : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_PROCEDURE()), ' - ')
		PRINT '		Error Line      : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_LINE()), ' - ')
		PRINT '		Error Message   : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_MESSAGE()), ' - ')
		/*SELECT
			ERROR_NUMBER() AS ErrorNumber,		-- Devuelve el n�mero interno del error
			ERROR_STATE() AS ErrorState,		-- Devuelve la informaci�n sobre la fuente
			ERROR_SEVERITY() AS ErrorSeverity,  -- Devuelve la informaci�n sobre cualquier cosa, desde errores informativos hasta errores que el usuario de DBA puede corregir, etc.
			ERROR_PROCEDURE() AS ErrorProcedure,-- Devuelve el nombre del procedimiento almacenado o la funci�n
			ERROR_LINE() AS ErrorLine,			-- Devuelve el n�mero de l�nea en el que ocurri� un error
			ERROR_MESSAGE() AS ErrorMessage*/   -- Devuelve la informaci�n m�s esencial y ese es el mensaje de texto del error
		PRINT '	 ** Posible solucion: Si no ha modificado el script, habilite el ALTER de la linea 5'
		--PRINT '		Error Message   : ' + ISNULL(CONVERT(NVARCHAR(MAX), ERROR_MESSAGE()), ' - ')
	END CATCH
GO

CREATE DATABASE [WebDBTransac]
GO

USE [WebDBTransac]
GO



CREATE TABLE [dbo].[Compra](

	[CMPID] [INT] NOT NULL IDENTITY,
	[Compra_Usuario] [INT] NOT NULL,
	[Consec_Compra] [INT] NOT NULL,
	[Destino] [NVARCHAR] (150) NOT NULL,
	[Cant_Boletos] [INT] NOT NULL,
	[TotalCompra] [FLOAT] NOT NULL

	CONSTRAINT [PK_COMPRA_CMPID] PRIMARY KEY([CMPID]),
)
GO

INSERT INTO [dbo].[Compra] values (1, 1, 'Costa Rica', 1, 25000)
GO

CREATE TABLE [dbo].[Reserva_Boleto](

	[RSVID] [INT] NOT NULL IDENTITY,
	[Reserva_Usuario] [INT] NOT NULL,
	[Consec_Reserva] [INT] NOT NULL,
	[Destino] [NVARCHAR] (150) NOT NULL,
	[Cant_Boletos] [INT] NOT NULL,
	[TotalCompra] [FLOAT] NOT NULL,
	[Num_Reserva] [INT] NOT NULL,
	[BookingID] [NVARCHAR] (7) NOT NULL

	CONSTRAINT [PK_RESERVA_RSVID] PRIMARY KEY([RSVID]),
	CONSTRAINT [UK_RESERVA_BOOK] UNIQUE(bookingID),
)
GO

INSERT INTO [dbo].[Reserva_Boleto] values (1, 1, 'Costa Rica', 1, 25000, 2000, 'ABCD75X')
GO



CREATE TABLE [dbo].[Tarjeta](

	[TID] [INT] NOT NULL IDENTITY,
	[Número_Tarjeta] [INT] NOT NULL,
	[Mes_Expiración] [INT] NOT NULL,
	[Año_Expiración] [INT] NOT NULL,
	[CVV] [INT] NOT NULL,
	[Tipo_Tarjeta] [NVARCHAR] (150) NOT NULL,
	[Tipo] [NVARCHAR] (150) NOT NULL

	CONSTRAINT [PK_Tarjeta_TID] PRIMARY KEY([TID]),
)
GO


CREATE TABLE [dbo].[Easy_Pay](

	[EPID] [INT] NOT NULL IDENTITY,
	[Número_Cuenta] [INT] NOT NULL,
	[CodigoSeguridad] [INT] NOT NULL,
	[Password] [NVARCHAR] (150) NOT NULL

	CONSTRAINT [PK_Easy_Pay_EPID] PRIMARY KEY([EPID]),
)
GO






-- Encriptacion de la base de datos
PRINT '... Encriptando BD ... Espere por favor ... '  


USE master;
GO
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'VvuelosWEB$Key';
GO

--Llave Maestra


OPEN MASTER KEY DECRYPTION BY PASSWORD = 'VvuelosWEB$Key';
GO
BACKUP MASTER KEY TO FILE = 'D:\Servicios Web\masterkey.mk' 
    ENCRYPTION BY PASSWORD = 'VvuelosWEB$Key';
GO


USE master;
GO 
-- Certificado
CREATE CERTIFICATE VueWEB_certificate WITH SUBJECT = 'Vuelos WEB Certificate';
GO

SELECT * FROM sys.certificates where [name] = 'VueWEB_certificate'
GO


BACKUP CERTIFICATE Vue_certificate TO FILE = 'D:\Servicios Web\VueWEB_certificate.cer'
   WITH PRIVATE KEY (
         FILE = 'D:\Servicios Web\VueWEB_certificate.pvk',
         ENCRYPTION BY PASSWORD = 'VueWEB_certificate');
GO

-- Proceso de Encriptacion 
USE WebDBTransac
GO

CREATE DATABASE ENCRYPTION KEY
   WITH ALGORITHM = AES_256
   ENCRYPTION BY SERVER CERTIFICATE VueWEB_certificate;
GO


ALTER DATABASE WebDBTransac SET ENCRYPTION ON;
GO



/* Verificar Encriptacion */
SELECT 
DB_NAME(database_id) AS 'Base de datos'
,Encryption_State AS 'Estado de Encriptacion'
,key_algorithm AS 'Algoritmo de Encriptacion'
,key_length AS 'Tamaño de la llave'
FROM sys.dm_database_encryption_keys
GO
SELECT 
NAME AS 'Base de Datos'
,IS_ENCRYPTED AS 'Estado' 
FROM sys.databases where name ='WebDBTransac'
GO