using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaDominio;

namespace capaNegocio
{
    public static class CN_cliente
    {
        public static List<Cliente> ListarCliente()
        {
            return CD_cliente.MostraCliente();
        }

        public static void InsertarCliente(Cliente cli)
        {
            CN_cliente.InsertarCliente(cli);
        }

        public static void buscarCliente(int id)
        {
          CD_cliente.buscarCliente(id);
        } 
    }
}
