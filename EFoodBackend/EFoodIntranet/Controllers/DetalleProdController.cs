using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class DetalleProdController : ApiController
    {

        // POST api/values      
        public HttpResponseMessage Post([FromBody] DetalleProd detalle_prod)
        {
            if (detalle_prod.agregar_detalle_prod("Insertar"))
            {
                var message = string.Format("Producto Agregado");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("Error al facturar productos");
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, message);
            }
        }
    }
}
