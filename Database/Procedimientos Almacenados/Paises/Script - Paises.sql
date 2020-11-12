
-- Stored Procedures Pais

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Paises
AS
SELECT * FROM dbo.Pais

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Inserta_Pais
( @Consec_Pais int,
  @CodPais nvarchar(150),
  @Nombre nvarchar(150),
  @Imagen nvarchar(max))

 AS

Insert into dbo.Pais(Consec_Pais, CodPais, Nombre,Imagen) values(@Consec_Pais, @CodPais, @Nombre,@Imagen)
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Pais(@PAISID int, @Consec_Pais bit, @CodPais nvarchar(150), @Nombre nvarchar(150), @Imagen nvarchar(max))  

AS  

update dbo.Pais set Consec_Pais = @Consec_Pais, CodPais = @CodPais, Nombre = @Nombre, Imagen = @Imagen
where PAISID = @PAISID;  
if @@rowcount <> 1   
raiserror('ID Pais Invalido',16,1) 

Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Eliminar_Pais
( @PAISID int)

 AS

Delete from dbo.Pais where PAISID = @PAISID
Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Filtro_Pais(@Nombre nvarchar(150))

AS

SELECT PAISID FROM dbo.Pais WHERE Nombre = @Nombre
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Consec_Pais(@PAISID int)

AS

Select Consec_Pais from dbo.Pais where PAISID = @PAISID   