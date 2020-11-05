USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Consecutivos

AS

SELECT * FROM dbo.Consecutivo

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Consecutivo
( @Descripcion nvarchar(150),
  @Consecutivo nvarchar(150),
  @Posee_Prefijo bit,
  @Prefijo nvarchar(150),
  @RangoInicial int,
  @RangoFinal int)

 AS

INSERT INTO dbo.Consecutivo(Descripcion,Consecutivo, Posee_Prefijo,Prefijo, RangoInicial, RangoFinal) VALUES (@Descripcion,@Consecutivo, @Posee_Prefijo, @Prefijo,@RangoInicial,@RangoFinal)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Go

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Consecutivo(@CSVID int, @Descripcion nvarchar(150), @Consecutivo nvarchar(150), @Posee_Prefijo bit, @Prefijo nvarchar(150), @RangoInicial int, @RangoFinal int )  

AS  

UPDATE dbo.Consecutivo SET Descripcion = @Descripcion, Consecutivo = @Consecutivo, Posee_Prefijo = @Posee_Prefijo, Prefijo = @Prefijo, RangoInicial = @RangoInicial, RangoFinal = @RangoFinal  
WHERE CSVID = @CSVID;  
IF @@rowcount <> 1   
RAISERROR('ID Consecutivo Invalido',16,1) 

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Go

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Consecutivo(@CSVID int)  

AS 

SELECT * FROM dbo.Consecutivo WHERE CSVID = @CSVID

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Go

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Consecutivo
( @CSVID int)

AS

DELETE FROM dbo.Consecutivo WHERE CSVID = @CSVID