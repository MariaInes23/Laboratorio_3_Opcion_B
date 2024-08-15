using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Opcion_B
{
    public class ClienteVIP : Cliente
    {
        public ClienteVIP(string nombre, string correo, string telefono)
                    : base(nombre, correo, telefono) { }

        public override double ObtenerDescuento()
        {
            return 0.1; 
        }
    }
}

