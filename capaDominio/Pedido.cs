namespace capaDominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public Pedido() { }

        public Pedido(int pIdCliente, string pIdProducto, int pCantidad, double pPrecio)
        {
            this.IdCliente = pIdCliente;
            this.IdProducto = pIdProducto;
            this.Cantidad = pCantidad;
            this.Precio = pPrecio;
        }
    }
}
