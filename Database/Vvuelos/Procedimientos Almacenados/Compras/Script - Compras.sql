USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Compras

AS

SELECT * FROM dbo.Compra

Go


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Compra
( 
  @Compra_Usuario int,
  @Consec_Compra int,
  @Destino nvarchar(150),
  @Cant_Boletos int,
  @TotalCompra float)


 AS

INSERT INTO dbo.Compra(Compra_Usuario, Consec_Compra, Destino, Cant_Boletos, TotalCompra)
VALUES (@Compra_Usuario, @Consec_Compra, @Destino,@Cant_Boletos,@TotalCompra)

GO
