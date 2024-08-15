using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Opcion_B
{
    public class Plato
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Plato(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Precio:C}";
        }
    }
}
