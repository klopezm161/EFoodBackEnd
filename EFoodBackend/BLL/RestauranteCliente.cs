using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;

namespace BLL
{
    public class RestauranteCliente
    {
        #region propiedades


        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }


        #endregion

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
       
       
        /// <summary>
        /// Metodo para agregar un consecutivo
        /// </summary>
        /// <param name="accion"></param>
        /// <returns></returns>
        public bool agregarCliente(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                //    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                if (accion.Equals("Insertar"))
                {
                    sql = "EF_agregar_cliente";
                }
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@nombre", SqlDbType.VarChar, _name);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@apellido", SqlDbType.VarChar, _lastName);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@telefono", SqlDbType.VarChar, _phone);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@direccion", SqlDbType.VarChar, _address);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return true;
                }
            }
        }

       

        #endregion
    }
}
