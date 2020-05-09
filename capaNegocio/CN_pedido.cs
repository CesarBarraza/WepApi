using capaDatos;
using capaDominio;
using System.Collections.Generic;

namespace capaNegocio
{
    public static class CN_pedido
    {
        public static List<Pedido>ListarPedido()
        {
            return CD_pedido.listarPedido();
        }

        public static void AgredarPedido(Pedido pedido)
        {
            CD_pedido.insertarPedido(pedido);
        }
    }
}
