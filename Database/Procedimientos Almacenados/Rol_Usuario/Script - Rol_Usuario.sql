USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Rol_Usuarios
AS

SELECT * FROM dbo.Rol_Usuario

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
GO
CREATE PROCEDURE SP_Inserta_Rol_Usuarios
( @USRID int,
  @ROLID int,
  @Estado int)

AS

INSERT INTO dbo.Rol_Usuario(USRID, ROLID, Estado) VALUES(@USRID, @ROLID,@Estado)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Estado_Administrador(@USRID int, @ROLID int, @Estado int)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Estado_Seguridad(@USRID int, @ROLID int, @Estado int)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Estado_Consecutivo(@USRID int, @ROLID int, @Estado int)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Estado_Mantenimiento(@USRID int, @ROLID int, @Estado int)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Estado_Consultas(@USRID int, @ROLID int, @Estado int)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Estado_Clientes(@USRID int, @ROLID int, @Estado int)  

AS  

update dbo.Rol_Usuario set Estado = @Estado
where USRID = @USRID AND ROLID = @ROLID;  
if @@rowcount <> 1   
raiserror('ID Usuario Invalido',16,1) 

Go