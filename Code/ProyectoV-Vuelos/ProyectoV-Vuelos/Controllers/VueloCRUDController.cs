using BLL;
using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoV_Vuelos.Controllers
{
    public class VueloCRUDController : Controller
    {
        public ActionResult IndexLlegada()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarVuelosLlegada() != null)
                {
                    return View(BuscarVuelosLlegada());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public ActionResult IndexSalida()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarVuelosSalida() != null)
                {
                    return View(BuscarVuelosSalida());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public List<VuelosModel> BuscarVuelos()
        {
            Errores Error = new Errores();

            try
            {
                Vuelos vuelos = new Vuelos();
                List<VuelosModel> lista =
                vuelos.SP_Solicitar_Info_Vuelos().Tables[0].AsEnumerable().Select(e => new VuelosModel
                {
                    VLOID = e.Field<int>("VLOID"),
                    Consec_Vuelo = e.Field<int>("Consec_Vuelo"),
                    Vuelo_Aerol = e.Field<int>("Vuelo_Aerol"),
                    Vuelo_Aerop = e.Field<int>("Vuelo_Aerop"),
                    CodVuelo = e.Field<string>("CodVuelo"),
                    Destino = e.Field<string>("Destino"),
                    Procedencia = e.Field<string>("Procedencia"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Estado = e.Field<string>("Estado"),
                    Monto = e.Field<double>("Monto")

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los vuelos en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public static string Fecha(string f)
        {
            string[] lista = f.Split(' ');
            string fecha = lista[0];

            return fecha;
        }

        public static string Hora(string f)
        {
            string[] lista = f.Split(' ');
            string hora = lista[1];

            return hora;
        }

        public List<VuelosModel> BuscarVuelosLlegada()
        {
            Errores Error = new Errores();

            try
            {
                Vuelos vuelos = new Vuelos();
                List<VuelosModel> lista =
                vuelos.SP_Solicitar_Vuelos_Llegada().Tables[0].AsEnumerable().Select(e => new VuelosModel
                {
                    VLOID = e.Field<int>("VLOID"),
                    Consec_Vuelo = e.Field<int>("Consec_Vuelo"),
                    //Vuelo_Aerol = e.Field<int>("Vuelo_Aerol"),
                    //Vuelo_Aerop = e.Field<int>("Vuelo_Aerop"),
                    Aerolinea = vuelos.SP_Solicitar_Aerolinea_Vuelo(e.Field<int>("VLOID")).Nombre,
                    Vuelo_Aerop = vuelos.SP_Solicitar_Aeropuerto_Vuelo(e.Field<int>("VLOID")).Num_Puerta,
                    CodVuelo = e.Field<string>("CodVuelo"),
                    Destino = e.Field<string>("Destino"),
                    Procedencia = e.Field<string>("Procedencia"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Fecha_Vuelo = Fecha(e.Field<DateTime>("Fecha").ToString()),
                    Hora = Hora(e.Field<DateTime>("Fecha").ToString()),
                    Estado = e.Field<string>("Estado"),
                    Monto = e.Field<double>("Monto")

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los vuelos en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public List<VuelosModel> BuscarVuelosSalida()
        {
            Errores Error = new Errores();

            try
            {
                Vuelos vuelos = new Vuelos();
                List<VuelosModel> lista =
                vuelos.SP_Solicitar_Vuelos_Salida().Tables[0].AsEnumerable().Select(e => new VuelosModel
                {
                    VLOID = e.Field<int>("VLOID"),
                    Consec_Vuelo = e.Field<int>("Consec_Vuelo"),
                    //Vuelo_Aerol = e.Field<int>("Vuelo_Aerol"),
                    //Vuelo_Aerop = e.Field<int>("Vuelo_Aerop"),
                    Aerolinea = vuelos.SP_Solicitar_Aerolinea_Vuelo(e.Field<int>("VLOID")).Nombre,
                    Vuelo_Aerop = vuelos.SP_Solicitar_Aeropuerto_Vuelo(e.Field<int>("VLOID")).Num_Puerta,
                    CodVuelo = e.Field<string>("CodVuelo"),
                    Destino = e.Field<string>("Destino"),
                    Procedencia = e.Field<string>("Procedencia"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Fecha_Vuelo = Fecha(e.Field<DateTime>("Fecha").ToString()),
                    Hora = Hora(e.Field<DateTime>("Fecha").ToString()),
                    Estado = e.Field<string>("Estado"),
                    Monto = e.Field<double>("Monto")

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los vuelos en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public string BuscarVueloID()
        {
            Errores Error = new Errores();

            try
            {
                Vuelos vuelos = new Vuelos();
                string VLOID = vuelos.SP_Solicitar_VLOID_Vuelos().Tables[0].Rows[0]["VLOID"].ToString();

                return VLOID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar el VLOID en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public ActionResult Generar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generar(VuelosModel v)
        {
            Vuelos VLO = new Vuelos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                string destino = v.Destino;
                string procedencia = v.Procedencia;

                if (destino == null)
                    destino = "";

                if (procedencia == null) 
                    procedencia = "";

                VLO.GenerarVuelo(v.Consec_Vuelo, v.Vuelo_Aerol, v.Vuelo_Aerop, v.CodVuelo, destino, procedencia, DateTime.Now, v.Estado, v.Monto);

                BTC.GenerarBitacora(v.Consec_Vuelo, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo Vuelo",
                    v.CodVuelo, VLO.SP_Solicitar_Aerolinea_Vuelo(Convert.ToInt32(BuscarVueloID())).Nombre, "", VLO.SP_Solicitar_Aeropuerto_Vuelo(Convert.ToInt32(BuscarVueloID())).Num_Puerta, "", "", "", destino, procedencia, v.Fecha, v.Estado, v.Monto);

                if (destino == "")
                    return RedirectToAction("IndexLlegada");
                else
                    return RedirectToAction("IndexSalida");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Vuelo", ex);
                Error.GenerarError(DateTime.Now, "Error al generar un nuevo vuelo en la Tabla Vuelo: " + ex);
                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarVuelos().Where(e => e.VLOID == id).First() != null)
                {
                    return View(BuscarVuelos().Where(e => e.VLOID == id).First());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al buscar un vuelo en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Actualizar(VuelosModel v)
        {
            Vuelos VLO = new Vuelos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                string destino = v.Destino;
                string procedencia = v.Procedencia;

                if (destino == null)
                    destino = "";

                if (procedencia == null)
                    procedencia = "";

                VLO.ActualizarVuelo(v.VLOID, v.Consec_Vuelo, v.Vuelo_Aerol, v.Vuelo_Aerop, v.CodVuelo, destino, procedencia, v.Fecha, v.Estado, v.Monto);

                BTC.GenerarBitacora(v.Consec_Vuelo, 1, 2, DateTime.Now, "Modificar", "Modificación de un Vuelo",
                    v.CodVuelo, VLO.SP_Solicitar_Aerolinea_Vuelo(v.VLOID).Nombre, "", VLO.SP_Solicitar_Aeropuerto_Vuelo(v.VLOID).Num_Puerta, "", "", "", destino, procedencia, v.Fecha, v.Estado, v.Monto);

                if (destino == "")
                    return RedirectToAction("IndexLlegada");
                else
                    return RedirectToAction("IndexSalida");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Vuelo", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar un vuelo en la Tabla Vuelo: " + ex);
                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Vuelos VLO = new Vuelos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            try
            {
                string destino = VLO.SP_Solicitar_Destino(id).Destino;

                BTC.GenerarBitacora(VLO.SP_Solicitar_Consec_Vuelo(id).Consec_Vuelo, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un Vuelo",
                "", "", "", 0, "", "", "", "", "", DateTime.Now, "", 0);
                VLO.EliminarVuelo(id);

                if (destino == "")
                    return RedirectToAction("IndexLlegada");
                else
                    return RedirectToAction("IndexSalida");
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al eliminar un vuelo en la Tabla Vuelo: " + ex);
                throw;
            }
        }
    }
}
