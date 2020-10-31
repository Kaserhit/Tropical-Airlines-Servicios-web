Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Consecutivos
AS
SELECT * FROM dbo.Consecutivo

exec SP_Solicitar_Info_Consecutivos

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Inserta_Consecutivo
( @Consec_Pais int,
  @Descripcion nvarchar(150),
  @Consecutivo nvarchar(150),
  @Prefijo nvarchar(150),
  @RangoInicial int,
  @RangoFinal int)

 AS

Insert into dbo.Consecutivo(Consec_Pais, Descripcion,Consecutivo,Prefijo, RangoInicial, RangoFinal) values(@Consec_Pais, @Descripcion,@Consecutivo, @Prefijo,@RangoInicial,@RangoFinal)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Actualiza_Consecutivo(@CSVID int, @Consec_Pais int, @Descripcion nvarchar(150), @Consecutivo nvarchar(150), @Prefijo nvarchar(150), @RangoInicial int, @RangoFinal int )  

AS  

update dbo.Consecutivo set Consec_Pais= @Consec_Pais, Descripcion = @Descripcion, Consecutivo = @Consecutivo, Prefijo = @Prefijo, RangoInicial = @RangoInicial, RangoFinal = @RangoFinal  
where CSVID = @CSVID;  
if @@rowcount <> 1   
raiserror('ID Consecutivo Invalido',16,1) 

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Consecutivo(@CSVID int)  
AS  
select * from dbo.Consecutivo where CSVID = @CSVID

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Use WebDB
Go
CREATE PROCEDURE SP_Eliminar_Consecutivo
( @CSVID int)

 AS

Delete from dbo.Consecutivo where CSVID = @CSVID