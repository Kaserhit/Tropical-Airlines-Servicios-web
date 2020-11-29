USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Vuelos

AS

SELECT * FROM dbo.Vuelo

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
  @Estado_Dest nvarchar(150),
  @Estado_Proced nvarchar(150),
  @Monto float)

 AS

INSERT INTO dbo.Vuelo(Consec_Vuelo, Vuelo_Aerol, Vuelo_Aerop, CodVuelo, Destino, Procedencia, Fecha, Estado_Dest, Estado_Proced, Monto)
VALUES (@Consec_Vuelo,@Vuelo_Aerol, @Vuelo_Aerop, @CodVuelo,@Destino,@Procedencia,@Fecha,@Estado_Dest,@Estado_Proced,@Monto)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Go

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Vuelo(@VLOID int, @Consec_Vuelo int, @Vuelo_Aerol int, @Vuelo_Aerop int, @CodVuelo nvarchar(150), @Destino nvarchar(150), 
@Procedencia nvarchar(150), @Fecha datetime, @Estado_Dest nvarchar(150), @Estado_Proced nvarchar(150), @Monto float)

AS  

UPDATE dbo.Vuelo SET Consec_Vuelo = @Consec_Vuelo, Vuelo_Aerol = @Vuelo_Aerol, Vuelo_Aerop = @Vuelo_Aerop, CodVuelo = @CodVuelo, Destino = @Destino, 
Procedencia = @Procedencia, Fecha = @Fecha, Estado_Dest = @Estado_Dest, Estado_Proced = @Estado_Proced, Monto = @Monto
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