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