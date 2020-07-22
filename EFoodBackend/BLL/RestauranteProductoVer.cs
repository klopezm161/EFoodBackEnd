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
   public class RestauranteProductoVer
    {
        #region propiedades
        private string _lineComida;
        public string lineComida
        {
            get { return _lineComida; }
            set { _lineComida = value; }
        }

        private string _producto;
        public string producto
        {
            get { return _producto; }
            set { _producto = value; }
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
        public string carga_lista_Productos(string linea, string producto)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {

                return null;
            }
            else
            {

                if (producto == null)
                {
                    sql = "EF_ver_Producto";
                    ParamStruct[] parametros = new ParamStruct[2];
                    cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@lineaComida", SqlDbType.VarChar, linea);
                    cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@producto", SqlDbType.VarChar, "");
                    ds = cls_DAL.ejecuta_dataset(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);

                }
                else 
                {
                    sql = "EF_ver_Producto";
                    ParamStruct[] parametros = new ParamStruct[2];
                    cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@lineaComida", SqlDbType.VarChar, linea);
                    cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@producto", SqlDbType.VarChar, producto);
                    ds = cls_DAL.ejecuta_dataset(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);


                }
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return JsonConvert.SerializeObject(ds.Tables[0]);
                }
            }

        }

        //public bool agregarProducto(string accion)
        //{
        //    conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
        //    if (conexion == null)
        //    {
        //        //insertar en la table de errores
        //        //    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //        return false;
        //    }
        //    else
        //    {
        //        if (accion.Equals("Insertar"))
        //        {
        //            sql = "crear_producto";
        //        }
        //        ParamStruct[] parametros = new ParamStruct[5];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@lineaComida", SqlDbType.VarChar, _linea_comida);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@descripcion", SqlDbType.VarChar, _descripcion);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@contenido", SqlDbType.VarChar, _contenido);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@foto", SqlDbType.VarChar, _foto);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@usuario", SqlDbType.VarChar, _usuario);
        //        cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
        //        cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        //        if (numero_error != 0)
        //        {
        //            //insertar en la table de errores
        //            //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return false;
        //        }
        //        else
        //        {
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return true;
        //        }
        //    }
        //}

        //public bool eliminarProducto(string cod)
        //{
        //    conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
        //    if (conexion == null)
        //    {
        //        //insertar en la table de errores
        //        //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //        return false;
        //    }
        //    else
        //    {
        //        sql = "eliminar_producto";
        //        ParamStruct[] parametros = new ParamStruct[2];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@codigo", SqlDbType.VarChar, _cod_prod);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@usuario", SqlDbType.VarChar, _usuario);
        //        cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
        //        cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        //        if (numero_error != 0)
        //        {
        //            //insertar en la table de errores
        //            //   HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return false;
        //        }
        //        else
        //        {
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return true;
        //        }
        //    }
        //}
        //public bool modificarProducto(string accion)
        //{
        //    conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
        //    if (conexion == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (accion.Equals("Actualizar"))
        //        {
        //            sql = "modificar_producto";
        //        }
        //        ParamStruct[] parametros = new ParamStruct[6];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@codigo", SqlDbType.VarChar, _cod_prod);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@lineaComida", SqlDbType.VarChar, _linea_comida);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@descripcion", SqlDbType.VarChar, _descripcion);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@contenido", SqlDbType.VarChar, _contenido);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@foto", SqlDbType.VarChar, _foto);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@usuario", SqlDbType.VarChar, _usuario);
        //        cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
        //        cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        //        if (numero_error != 0)
        //        {
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return false;
        //        }
        //        else
        //        {
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return true;
        //        }
        //    }
        //}
        #endregion
    }
}
