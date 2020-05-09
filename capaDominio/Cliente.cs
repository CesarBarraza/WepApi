using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDominio
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; }

        public Cliente() { }

        public Cliente(int cIdCli, string cNombre, string cApellido, string cFecha, string cDireccion)
        {
            this.IDCliente = cIdCli;
            this.Nombre = cNombre;
            this.Apellido = cApellido;
            this.Fecha_Nacimiento = cFecha;
            this.Direccion = cDireccion;
        }

    }
}

