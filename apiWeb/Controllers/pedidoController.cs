using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using capaNegocio;
using capaDominio;
using System.Web.Http.Cors;

namespace apiWeb.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class pedidoController : ApiController
    {
        // GET: api/pedido
        public IEnumerable<Pedido> Get()
        {
            return CN_pedido.ListarPedido();
        }

        // GET: api/pedido/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/pedido
        public void Post([FromBody]Pedido pedido)
        {
            CN_pedido.AgredarPedido(pedido);
        }

        // PUT: api/pedido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/pedido/5
        public void Delete(int id)
        {
        }
    }
}
