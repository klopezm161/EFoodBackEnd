using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class DetalleController : ApiController
    {
        // GET api/values       
        public string Get()
        {
            return new Detalle().carga_detalle();
        }
        // POST api/values      
        public HttpResponseMessage Post([FromBody] Detalle detalle)
        {
            if (detalle.agregar_detalle("Insertar"))
            {
                var message = string.Format("Factura generada");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("Hubo un error con al generar la factura");
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, message);
            }
        }

    }
}
