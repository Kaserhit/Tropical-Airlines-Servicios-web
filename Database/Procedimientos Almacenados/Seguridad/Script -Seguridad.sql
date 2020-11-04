USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Usuarios

AS

SELECT * FROM dbo.Usuario

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Usuario
( @ID_Rol int,	
  @Usuario nvarchar(150),
  @Contrasena nvarchar(150),
  @Nombre nvarchar(150),
  @Primer_Apellido nvarchar(150),
  @Segundo_Apellido nvarchar(150),
  @Pregunta nvarchar(150),
  @Respuesta nvarchar(150),
  @Correo nvarchar(150))

 AS

INSERT INTO dbo.Usuario(ID_Rol,Usuario,Contrasena, Nombre, Primer_Apellido,Segundo_Apellido,Pregunta,Respuesta,Correo) VALUES (@ID_Rol,@Usuario, @Contrasena,@Nombre,@Primer_Apellido,@Segundo_Apellido,@Pregunta,@Respuesta,@Correo)
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Actualiza_Usuario(@USRID int, @ID_Rol int)  

AS  

UPDATE dbo.Usuario SET ID_Rol = @ID_Rol 
WHERE USRID = @USRID;  
IF @@rowcount <> 1   
RAISERROR('Fallo en la Actualizacion de rol',16,1) 
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
CREATE PROCEDURE SP_Solicitar_Info_Usuario(@USRID int)  

AS 

SELECT * FROM dbo.Usuario WHERE USRID = @USRID
Go
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Eliminar_Usuario
( @USRID int)

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


