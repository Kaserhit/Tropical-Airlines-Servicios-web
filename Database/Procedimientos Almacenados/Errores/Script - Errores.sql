USE WebDB
GO
CREATE PROCEDURE SP_Solicitar_Info_Errores

AS

SELECT * FROM dbo.Error
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
GO
CREATE PROCEDURE SP_Inserta_Error
( @Fecha datetime,
  @Mensaje_Error nvarchar(150))

AS

INSERT INTO dbo.Error(Fecha, Mensaje_Error) VALUES(@Fecha, @Mensaje_Error)