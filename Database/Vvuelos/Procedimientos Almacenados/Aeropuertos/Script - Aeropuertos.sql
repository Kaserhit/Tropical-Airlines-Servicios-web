USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Aeropuertos

AS

SELECT * FROM dbo.Aeropuerto

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Aeropuerto
( @Consec_Aerop int,
  @Cod_Puerta nvarchar(150),
  @Num_Puerta int,
  @Detalle nvarchar(150))

 AS

INSERT INTO dbo.Aeropuerto(Consec_Aerop, Cod_Puerta, Num_Puerta, Detalle) VALUES (@Consec_Aerop, @Cod_Puerta, @Num_Puerta, @Detalle)
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Aeropuerto(@APTID int, @Consec_Aerop int, @Cod_Puerta nvarchar(150), @Num_Puerta int, @Detalle nvarchar(150))  

AS  

UPDATE dbo.Aeropuerto SET Consec_Aerop= @Consec_Aerop, Cod_Puerta = @Cod_Puerta, Num_Puerta = @Num_Puerta, Detalle = @Detalle  
WHERE APTID = @APTID;  
IF @@rowcount <> 1   
RAISERROR('ID Aeropuerto Invalido',16,1) 
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Aeropuerto
( @APTID int)

AS

DELETE FROM dbo.Aeropuerto WHERE APTID = @APTID
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Consec_Aeropuerto(@APTID int)

AS

Select Consec_Aerop from dbo.Aeropuerto where APTID = @APTID