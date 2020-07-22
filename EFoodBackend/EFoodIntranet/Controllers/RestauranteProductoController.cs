using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class RestauranteProductoController : ApiController
    {
        // GET: api/RestauranteProducto
        public string Get(string linea, string producto )
        {
            return new RestauranteProductoVer().carga_lista_Productos(linea, producto);

        }

        // GET: api/RestauranteProducto/5
       
    }
}
