USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Bitacoras

AS

SELECT * FROM dbo.Bitacora

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Bitacora
( @Consec_Bitacora int,
  @Usuario_Bitac int,
  @Cod_Registro int,
  @Fecha datetime,
  @Tipo nvarchar(150),
  @Descripcion nvarchar(150))

 AS

INSERT INTO dbo.Bitacora(Consec_Bitacora, Usuario_Bitac, Cod_Registro, Fecha, Tipo, Descripcion) VALUES (@Consec_Bitacora,@Usuario_Bitac, @Cod_Registro, @Fecha,@Tipo,@Descripcion)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Go

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Bitacora(@BTCID int, @Consec_Bitacora int, @Usuario_Bitac int, @Cod_Registro int, @Fecha datetime, @Tipo nvarchar(150), @Descripcion nvarchar(150))  

AS  

UPDATE dbo.Bitacora SET Consec_Bitacora = @Consec_Bitacora, Usuario_Bitac = @Usuario_Bitac, Cod_Registro = @Cod_Registro, Fecha = @Fecha, Tipo = @Tipo, Descripcion = @Descripcion  
WHERE BTCID = @BTCID;  
IF @@rowcount <> 1   
RAISERROR('ID Bitacora Invalido',16,1) 
