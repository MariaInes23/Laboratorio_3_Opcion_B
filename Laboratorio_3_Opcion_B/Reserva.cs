using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Opcion_B
{
    public class Reserva
    {
        public int Numero { get; set; }
        public string FechaHora { get; set; } 
        public Cliente Cliente { get; set; }
        public List<Plato> Platos { get; set; }
        public double Total => CalcularTotal();

        public Reserva(int numero, string fechaHora, Cliente cliente, List<Plato> platos)
        {
            Numero = numero;
            FechaHora = fechaHora;
            Cliente = cliente;
            Platos = platos;
        }

        private double CalcularTotal()
        {
            double total = Platos.Sum(plato => plato.Precio);
            double descuento = Cliente.ObtenerDescuento();
            return total - (total * descuento);
        }

        public override string ToString()
        {
            return $"Reserva #{Numero}: {FechaHora} - Cliente: {Cliente.Nombre}, Total: {Total:C}";
        }
    }
}
