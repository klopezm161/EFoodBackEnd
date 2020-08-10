using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class RestauranteClienteController : ApiController
    {
        // POST api/values      
        public HttpResponseMessage Post([FromBody] RestauranteCliente cliente)
        {
            if (cliente.agregarCliente("Insertar"))
            {
                var message = string.Format("Se guardó con éxito el cliente");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("No se guardó el cliente, verifique los datos.");
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, message);
            }
        }
    }
}
