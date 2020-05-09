using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using capaDominio;

namespace capaDatos
{
    public class CD_cliente
    {
        public static List<Cliente> MostraCliente()
        {
            List<Cliente> _lista = new List<Cliente>();

            SqlCommand _comando = new SqlCommand("GetCliente", ConexionBD.ConexionSql());
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Cliente cli = new Cliente();
                cli.IDCliente = _reader.GetInt32(0);
                cli.Nombre = _reader.GetString(1);
                cli.Apellido = _reader.GetString(2);
                cli.Fecha_Nacimiento = _reader.GetString(3);
                cli.Direccion = _reader.GetString(4);


                _lista.Add(cli);
            }

            return _lista;
        }

        //Consuta a la BD para insertar un Producto
        public static void insertarCliente(Cliente cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertarCliente", ConexionBD.ConexionSql());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@fNacimiento", cliente.Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                _ = e.Message;
            }
        }

        //buscar cliente por id
        public static void buscarCliente(int id)

        { 
            try
            {
                SqlCommand cmd = new SqlCommand("BuscarCliente", ConexionBD.ConexionSql());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Consulta a la BD para editar
        /*public static void Edit(Producto producto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionBD.ConexionSql();
            cmd.CommandText = "EditarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", producto.IDProducto);
            cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@desc", producto.Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Precio);
            cmd.Parameters.AddWithValue("@stock", producto.Stock);
            cmd.ExecuteNonQuery();
        }

        //Consulta a la BD para eliminar Producto
        public static void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionBD.ConexionSql();
            cmd.CommandText = "EliminarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }*/
    }
}
