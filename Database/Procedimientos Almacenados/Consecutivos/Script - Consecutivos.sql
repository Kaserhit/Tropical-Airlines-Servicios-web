USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Consecutivos

AS

SELECT * FROM dbo.Consecutivo

EXEC SP_Solicitar_Info_Consecutivos

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Consecutivo
( @Consec_Pais int,
  @Descripcion nvarchar(150),
  @Consecutivo nvarchar(150),
  @Prefijo nvarchar(150),
  @RangoInicial int,
  @RangoFinal int)

 AS

INSERT INTO dbo.Consecutivo(Consec_Pais, Descripcion,Consecutivo,Prefijo, RangoInicial, RangoFinal) VALUES (@Consec_Pais, @Descripcion,@Consecutivo, @Prefijo,@RangoInicial,@RangoFinal)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Consecutivo(@CSVID int, @Consec_Pais int, @Descripcion nvarchar(150), @Consecutivo nvarchar(150), @Prefijo nvarchar(150), @RangoInicial int, @RangoFinal int )  

AS  

UPDATE dbo.Consecutivo SET Consec_Pais= @Consec_Pais, Descripcion = @Descripcion, Consecutivo = @Consecutivo, Prefijo = @Prefijo, RangoInicial = @RangoInicial, RangoFinal = @RangoFinal  
WHERE CSVID = @CSVID;  
IF @@rowcount <> 1   
RAISERROR('ID Consecutivo Invalido',16,1) 

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Consecutivo(@CSVID int)  

AS 

SELECT * FROM dbo.Consecutivo WHERE CSVID = @CSVID

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Consecutivo
( @CSVID int)

AS

DELETE FROM dbo.Consecutivo WHERE CSVID = @CSVID