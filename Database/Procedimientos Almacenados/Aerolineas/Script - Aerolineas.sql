USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Aerolineas

AS

SELECT * FROM dbo.Aerolinea

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Aerolinea
( @Aerol_Pais int,
  @Consec_Aerol int,
  @Codigo nvarchar(150),
  @Nombre nvarchar(150),
  @Imagen nvarchar(max))

 AS

INSERT INTO dbo.Aerolinea(Aerol_Pais, Consec_Aerol, Codigo, Nombre, Imagen) VALUES (@Aerol_Pais, @Consec_Aerol, @Codigo, @Nombre, @Imagen)
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Aerolinea(@ALNID int, @Aerol_Pais int, @Consec_Aerol int, @Codigo nvarchar(150), @Nombre nvarchar(150), @Imagen nvarchar(max))

AS  

UPDATE dbo.Aerolinea SET Aerol_Pais = @Aerol_Pais, Consec_Aerol = @Consec_Aerol, Codigo = @Codigo, Nombre = @Nombre, Imagen = @Imagen
WHERE ALNID = @ALNID;  
IF @@rowcount <> 1   
RAISERROR('ID Aerolinea Invalido',16,1) 
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Aerolinea(@ALNID int)  

AS 

SELECT * FROM dbo.Aerolinea WHERE ALNID = @ALNID
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Aerolinea
( @ALNID int)

AS

DELETE FROM dbo.Aerolinea WHERE ALNID = @ALNID