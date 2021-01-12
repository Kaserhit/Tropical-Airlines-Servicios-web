USE WebDB
Go
CREATE PROCEDURE SP_Solicitar_Info_Reservas

AS

SELECT * FROM dbo.Reserva_Boleto

Go


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE WebDB
Go
CREATE PROCEDURE SP_Inserta_Reservas
( 
  @Reserva_Usuario int,
  @Consec_Reserva int,
  @Destino nvarchar(150),
  @Cant_Boletos int,
  @TotalCompra float,
  @Num_Reserva int,
  @BookingID nvarchar(7))


 AS

INSERT INTO dbo.Reserva_Boleto(Reserva_Usuario, Consec_Reserva, Destino, Cant_Boletos, TotalCompra, Num_Reserva, BookingID)
VALUES (@Reserva_Usuario, @Consec_Reserva, @Destino,@Cant_Boletos,@TotalCompra,@Num_Reserva,@BookingID)

GO