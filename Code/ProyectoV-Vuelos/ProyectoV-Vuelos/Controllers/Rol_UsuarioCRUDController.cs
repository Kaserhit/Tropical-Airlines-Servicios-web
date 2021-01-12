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
    public class Rol_UsuarioCRUDController : Controller
    {
        public List<Rol_UsuariosModel> Buscar_Rol_Usuarios()
        {
            Errores Error = new Errores();
            Rol_Usuarios Roles = new Rol_Usuarios();

            try
            {
                List<Rol_UsuariosModel> lista =
                Roles.SP_Solicitar_Info_Rol_Usuarios().Tables[0].AsEnumerable().Select(e => new Rol_UsuariosModel
                {
                    USRID = e.Field<int>("USRID"),
                    ROLID = e.Field<int>("ROLID"),
                    Estado = e.Field<bool>("Estado"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los roles de usuarios en la Tabla Rol_Usuario: " + ex);
                throw;
            }
        }
    }
}