using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using capaDominio;
using capaNegocio;

namespace apiWeb.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class clienteController : ApiController
    {
        // GET: api/cliente
        public IEnumerable<Cliente> Get()
        {
            return CN_cliente.ListarCliente();
        }

        // GET: api/cliente/5
        public void Get(int id)
        {
          CN_cliente.buscarCliente(id);
        }

        // POST: api/cliente
        public void Post([FromBody]Cliente cli)
        {
            CN_cliente.InsertarCliente(cli);
        }

        // PUT: api/cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/cliente/5
        public void Delete(int id)
        {
        }
    }
}
