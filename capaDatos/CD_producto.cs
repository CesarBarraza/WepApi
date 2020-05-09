using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using capaDominio;

namespace CapaDatos
{
    public class CD_producto
    {
        //Consulata a la BD todos los registros
        public static List<Producto> Mostra()
        {
            List<Producto> _lista = new List<Producto>();

            SqlCommand _comando = new SqlCommand("MostrarProductos", ConexionBD.ConexionSql());
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Producto pro = new Producto();
                pro.IDProducto = _reader.GetInt32(0);
                pro.Nombre = _reader.GetString(1);
                pro.Descripcion = _reader.GetString(2);
                pro.Precio = _reader.GetDouble(3);
                pro.Stock = _reader.GetInt32(4);


                _lista.Add(pro);
            }

            return _lista;
            /*SqlDataReader leer;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "MostrarProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;*/
        }

        //Consuta a la BD para insertar un Producto
        public static void insertarProducto(Producto producto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insertarProducto", ConexionBD.ConexionSql());
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@desc", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                _ = e.Message;
            }

        }

        //Consulta a la BD para editar
        public static void Edit(Producto producto)
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

        //Consulta a la BD para buscar Producto
       /* public void BuscarProducto(GridView data, string nombre)
        {          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionBD.ConexionSql();
            cmd.CommandText = "BuscarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            data.DataSource = tabla;
        }*/

    }
}
