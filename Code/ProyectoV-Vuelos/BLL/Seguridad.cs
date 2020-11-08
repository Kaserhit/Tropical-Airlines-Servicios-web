using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Seguridad
    {
        #region Propiedades

        public int USRID { get; set; }

        public int ID_Rol { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string Nombre { get; set; }

        public string Primer_Apellido { get; set; }

        public string Segundo_Apellido { get; set; }

        public string Pregunta { get; set; }

        public string Respuesta { get; set; }

        public string Correo { get; set; }


        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos
        public DataSet SP_Solicitar_Info_Usuarios()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else {
                sql = "dbo.SP_Solicitar_Info_Usuarios";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else {
                    return ds;
                }
            }                        
        }

        public DataSet SP_Solicitar_Info_Usuario()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Usuario";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ds;
                }
            }
        }

        public DataSet Generar(int ID_Rol, string Usuario, string Contrasena, string Nombre, string Primer_Apellido, string Segundo_Apellido, string Pregunta, string Respuesta, string Correo)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
     
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Rol", ID_Rol);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Primer_Apellido", Primer_Apellido);
                cmd.Parameters.AddWithValue("@Segundo_Apellido", Segundo_Apellido);
                cmd.Parameters.AddWithValue("@Pregunta", Pregunta);
                cmd.Parameters.AddWithValue("@Respuesta", Respuesta);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Actualizar(int USRID, int ID_Rol)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ID_Rol", ID_Rol);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                return ds; 
            }
            finally
            {
                conexion.Close();
            }
        }

        public Boolean Login(string Usuario, string Contrasena)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Login_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", Contrasena));

                cmd.ExecuteNonQuery();
                conexion.Close();


                int id = (int)returnParameter.Value;

                if (id == 1)
                {
                    return true;
                }
                else 
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }


        }

        public DataSet Actualizarcontrasena(string contrasena, string newcontrasena)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_contrasena", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@newcontrasena", newcontrasena);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        #endregion
    }
}  

      

    

