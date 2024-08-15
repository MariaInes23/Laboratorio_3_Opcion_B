using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Opcion_B
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }

        public Cliente(string nombre, string correo, string telefono)
        {
            Nombre = nombre;
            CorreoElectronico = correo;
            NumeroTelefono = telefono;
        }

        public virtual double ObtenerDescuento()
        {
            return 0; 
        }

        public override string ToString()
        {
            return $"{Nombre} ({CorreoElectronico}, {NumeroTelefono})";
        }
    }
}
