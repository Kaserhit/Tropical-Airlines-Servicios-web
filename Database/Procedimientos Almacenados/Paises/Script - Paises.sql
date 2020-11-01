
-- Stored Procedures Pais

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Paises
AS
SELECT * FROM dbo.Pais



-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Inserta_Pais
( @CodPais nvarchar(150),
  @Nombre nvarchar(150),
  @Imagen nvarchar(max))

 AS

Insert into dbo.Pais(CodPais, Nombre,Imagen) values(@CodPais, @Nombre,@Imagen)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Pais(@PAISID int, @CodPais nvarchar(150), @Nombre nvarchar(150), @Imagen nvarchar(max))  

AS  

update dbo.Pais set  CodPais = @CodPais, Nombre = @Nombre, Imagen = @Imagen
where PAISID = @PAISID;  
if @@rowcount <> 1   
raiserror('ID Pais Invalido',16,1) 


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Pais(@PAISID int)  
AS  
select * from dbo.Pais where PAISID = @PAISID

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Eliminar_Pais
( @PAISID int)

 AS

Delete from dbo.Pais where PAISID = @PAISID