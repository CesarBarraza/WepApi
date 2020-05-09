using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using capaDominio;

namespace capaDatos
{
    public class CD_pedido
    {
        public static List<Pedido> listarPedido()
        {

            List<Pedido> list = new List<Pedido>();
            SqlCommand cmd = new SqlCommand("MostrarPedidos", ConexionBD.ConexionSql());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pedido pe = new Pedido();
                    pe.IdCliente = reader.GetInt32(0);
                    //pe.IdCliente = reader.GetString(0);
                    pe.IdProducto = reader.GetString(1);
                    pe.Cantidad = reader.GetInt32(2);
                    pe.Precio = reader.GetDouble(3);
                    list.Add(pe);
                }
            return list;
        }

        public static void insertarPedido(Pedido pedido)
        {
                Producto producto = new Producto();
                SqlCommand cmd = new SqlCommand("InsertarPedido", ConexionBD.ConexionSql());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
                cmd.Parameters.AddWithValue("@IdProducto", pedido.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", pedido.Cantidad);
                cmd.Parameters.AddWithValue("@precio", pedido.Precio);
                cmd.ExecuteNonQuery();
        }
    }
}
