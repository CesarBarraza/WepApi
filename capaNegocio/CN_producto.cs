using System.Collections.Generic;
using System.Windows.Forms;
using CapaDatos;
using capaDominio;

namespace CapaNegocio
{
    public static class CN_producto
    {
        public static List<Producto>MostrarProductos()
        {
            //CD_producto cD_Producto = new CD_producto();
            //DataTable tabla = new DataTable();
            //tabla = cD_Producto.Mostra();
            return CD_producto.Mostra();
        }

        public static void agregarProducto(Producto producto)
        {
            if (!ValidarFormulario(producto))
            {
                MessageBox.Show("Debe completar todos los datos del formulario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(producto.IDProducto == 0)
            {
                CD_producto cD_Producto = new CD_producto();
                CD_producto.insertarProducto(producto);
                MessageBox.Show("Se agrego el producto " + producto.Nombre + " con exito", "Aviso");
            }
            else
            {
                EditarProducto(producto);
            }
        }

        public static void EditarProducto(Producto producto)
        {
            CD_producto.Edit(producto);
            //CD_producto cD_Producto = new CD_producto();
            //cD_Producto.Edit(producto);
            MessageBox.Show("Se edito el producto " + producto.Nombre+ " con exito", "Aviso");
        }

        public static void EliminarProducto(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("No hay elemento seleccionado para eleminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Estas seguro de eliminar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CD_producto.Eliminar(id);
                //cD_Producto.Eliminar(id);
            }
        }

        /*public void BuscarProducto(GridView data ,string nombre)
        {
            CD_producto cD_Producto = new CD_producto();
            cD_Producto.BuscarProducto(data, nombre);
        }*/

        //Metodo para validar el formulario
        public static bool ValidarFormulario(Producto producto)
        {
            bool valido = true;
            if (producto.Nombre == "" || producto.Descripcion == "" || producto.Precio == 0 || producto.Stock == 0)
            {
                valido = false;
            }
            else
            {
                valido = true;
            }
            return valido;
        }
    }
}
