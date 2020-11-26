USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Usuarios

AS

SELECT * FROM dbo.Usuario

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_USRID_Usuarios

AS

SELECT TOP 1 USRID FROM dbo.Usuario ORDER BY USRID DESC

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Usuario
( @Usuario nvarchar(150),
  @Contrasena nvarchar(150),
  @Nombre nvarchar(150),
  @Primer_Apellido nvarchar(150),
  @Segundo_Apellido nvarchar(150),
  @Pregunta nvarchar(150),
  @Respuesta nvarchar(150),
  @Correo nvarchar(150),
  @Administrador bit,
  @Seguridad bit,
  @Consecutivo bit,
  @Mantenimiento bit,
  @Consulta bit,
  @Cliente bit)

 AS

INSERT INTO dbo.Usuario(Usuario,Contrasena, Nombre, Primer_Apellido,Segundo_Apellido,Pregunta,Respuesta,Correo,Administrador,Seguridad,Consecutivo,Mantenimiento,Consulta,Cliente) VALUES (@Usuario, @Contrasena,@Nombre,@Primer_Apellido,@Segundo_Apellido,@Pregunta,@Respuesta,@Correo,0,0,0,0,0,1)
Go

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_contrasena(@Contrasena nvarchar(150), @newContrasena nvarchar(150))  

AS  

UPDATE dbo.Usuario SET Contrasena = @newContrasena 
WHERE Contrasena = @Contrasena;  
IF @@rowcount <> 1   
RAISERROR('Fallo en la Actualizacion de la contrasena',16,1) 
Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Usuario
(@USRID int)

AS

DELETE FROM dbo.Usuario WHERE USRID = @USRID

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Login_Usuario(@Usuario nvarchar (150), @Contrasena nvarchar (150))  

AS 

Begin

declare @return int;

set @return  = (SELECT COUNT(*) FROM dbo.Usuario  WHERE Usuario = @Usuario  AND Contrasena = @Contrasena);

return @return;

End

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Rol_Administrador(@USRID int, @Administrador bit)  

AS  

update dbo.Usuario set Administrador = @Administrador
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Rol_Seguridad(@USRID int, @Seguridad bit)  

AS  

update dbo.Usuario set Seguridad = @Seguridad
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Rol_Consecutivo(@USRID int, @Consecutivo bit)  

AS  

update dbo.Usuario set Consecutivo = @Consecutivo 
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Rol_Mantenimiento(@USRID int, @Mantenimiento bit)  

AS  

update dbo.Usuario set Mantenimiento = @Mantenimiento 
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Rol_Consulta(@USRID int, @Consulta bit)  

AS  

update dbo.Usuario set Consulta= @Consulta
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Rol_Cliente(@USRID int, @Cliente bit)  

AS  

update dbo.Usuario set Cliente = @Cliente 
where USRID = @USRID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1)