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
  @Num_Puerta int,
  @Detalle nvarchar(150),
  @Consec_Descripcion nvarchar(150),
  @Consecutivo nvarchar(150),
  @Destino nvarchar(150),
  @Procedencia nvarchar(150),
  @Fecha_Vuelo datetime,
  @Estado nvarchar(150),
  @Monto float)

 AS

INSERT INTO dbo.Bitacora(Consec_Bitacora, Usuario_Bitac, Cod_Registro, Fecha, Tipo, Descripcion, Codigo, Nombre, Imagen, Num_Puerta, Detalle, Consec_Descripcion, Consecutivo, Destino, Procedencia, Fecha_Vuelo, Estado, Monto) 
VALUES (@Consec_Bitacora,@Usuario_Bitac, @Cod_Registro, @Fecha,@Tipo,@Descripcion,@Codigo,@Nombre,@Imagen,@Num_Puerta,@Detalle,@Consec_Descripcion,@Consecutivo,@Destino, @Procedencia,@Fecha_Vuelo,@Estado,@Monto)