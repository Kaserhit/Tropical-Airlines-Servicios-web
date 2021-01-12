USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Vuelos

AS

SELECT * FROM dbo.Vuelo

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_VLOID_Vuelos

AS

SELECT TOP 1 VLOID FROM dbo.Vuelo ORDER BY VLOID DESC

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Vuelos_Llegada

AS

SELECT * FROM dbo.Vuelo WHERE Procedencia != ''

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Vuelos_Salida

AS

SELECT * FROM dbo.Vuelo WHERE Destino != ''

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Vuelo
( @Consec_Vuelo int,
  @Vuelo_Aerol int,
  @Vuelo_Aerop int,
  @CodVuelo nvarchar(150),
  @Destino nvarchar(150),
  @Procedencia nvarchar(150),
  @Fecha datetime,
  @Estado nvarchar(150),
  @Monto float)

 AS

INSERT INTO dbo.Vuelo(Consec_Vuelo, Vuelo_Aerol, Vuelo_Aerop, CodVuelo, Destino, Procedencia, Fecha, Estado, Monto)
VALUES (@Consec_Vuelo,@Vuelo_Aerol, @Vuelo_Aerop, @CodVuelo,@Destino,@Procedencia,@Fecha,@Estado,@Monto)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Go

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Vuelo(@VLOID int, @Consec_Vuelo int, @Vuelo_Aerol int, @Vuelo_Aerop int, @CodVuelo nvarchar(150), @Destino nvarchar(150), 
@Procedencia nvarchar(150), @Fecha datetime, @Estado nvarchar(150), @Monto float)

AS  

UPDATE dbo.Vuelo SET Consec_Vuelo = @Consec_Vuelo, Vuelo_Aerol = @Vuelo_Aerol, Vuelo_Aerop = @Vuelo_Aerop, CodVuelo = @CodVuelo, Destino = @Destino, 
Procedencia = @Procedencia, Fecha = @Fecha, Estado = @Estado, Monto = @Monto
WHERE VLOID = @VLOID;  
IF @@rowcount <> 1   
RAISERROR('ID Vuelo Invalido',16,1) 
Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Vuelo
(@VLOID int)

AS

DELETE FROM dbo.Vuelo WHERE VLOID = @VLOID
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Consec_Vuelo(@VLOID int)

AS

Select Consec_Vuelo from dbo.Vuelo where VLOID = @VLOID
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Destino(@VLOID int)

AS

Select Destino from dbo.Vuelo where VLOID = @VLOID
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Aerolinea_Vuelo(@VLOID int)

AS

SELECT Aerolinea.Nombre FROM dbo.Vuelo INNER JOIN dbo.Aerolinea ON Vuelo.Vuelo_Aerol = Aerolinea.ALNID WHERE Vuelo.VLOID = @VLOID
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Aeropuerto_Vuelo(@VLOID int)

AS

SELECT Aeropuerto.Num_Puerta FROM dbo.Vuelo INNER JOIN dbo.Aeropuerto ON Vuelo.Vuelo_Aerop = Aeropuerto.APTID WHERE Vuelo.VLOID = @VLOID
GO