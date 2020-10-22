using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Lec04.Models;

namespace Lec04.Data
{
    public class FacturasData
    {

        public List<FacturasModel> selectData() {
            try
            {
                Facturas Facturas = new Facturas();
                List<FacturasModel> lista =
                Facturas.traer_lista_Facturas().Tables[0].AsEnumerable().Select(e => new FacturasModel
                {
                    Num_Factura = e.Field<int>("Num_Factura"),
                    Fecha_Factura = e.Field<DateTime>("Fecha_Factura"),
                    Total = e.Field<Decimal>("Total"),
            }).ToList();

                return lista;
            }
            catch (Exception ex)
            {

                    Console.WriteLine("Valor Null detectado");
                throw;
            }
        }
    }
}
