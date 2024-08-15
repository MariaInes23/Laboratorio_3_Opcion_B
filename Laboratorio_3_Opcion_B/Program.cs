using Laboratorio_3_Opcion_B;
using System;

public class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static List<Reserva> reservas = new List<Reserva>();
    static int siguienteNumeroReserva = 1;

    static void Main(string[] args)
    {
        int opcion;

        do
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------");
            Console.WriteLine("RESERVAS DE TRESTAURANTE");
            Console.WriteLine("--------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1. Registrar Cliente Regular");
            Console.WriteLine("2. Registrar Cliente VIP");
            Console.WriteLine("3. Registrar Reserva");
            Console.WriteLine("4. Mostrar Detalles de Clientes");
            Console.WriteLine("5. Mostrar Detalles de Reservas");
            Console.WriteLine("6. Buscar Cliente por Nombre");
            Console.WriteLine("7. Buscar Reservas por Número");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");

            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarCliente(false);
                        break;
                    case 2:
                        RegistrarCliente(true);
                        break;
                    case 3:
                        RegistrarReserva();
                        break;
                    case 4:
                        MostrarDetallesClientes();
                        break;
                    case 5:
                        MostrarDetallesReservas();
                        break;
                    case 6:
                        BuscarCliente();
                        break;
                    case 7:
                        BuscarReserva();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Saliendo del programa...");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                opcion = -1;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                opcion = -1;
            }
        } while (opcion != 8);
    }

    static void RegistrarCliente(bool esVIP)
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("REGISTRAR CLIENTE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el correo electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Ingrese el número de teléfono: ");
            string telefono = Console.ReadLine();

            Cliente nuevoCliente;

            if (esVIP)
            {
                nuevoCliente = new ClienteVIP(nombre, correo, telefono);
            }
            else
            {
                nuevoCliente = new Cliente(nombre, correo, telefono);
            }

            clientes.Add(nuevoCliente);
            Console.WriteLine("Cliente registrado exitosamente.\n");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocurrió un error al registrar el cliente: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void RegistrarReserva()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("REGISTRAR RESERVA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Ingrese el nombre del cliente para la reserva: ");
            string nombreCliente = Console.ReadLine();
            Cliente cliente = clientes.FirstOrDefault(c => c.Nombre.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase));

            if (cliente == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cliente no encontrado.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese la fecha y hora de la reserva (DIA-MES-AÑO HORA:MINUTOS): ");
            string fechaHora = Console.ReadLine(); 

            List<Plato> platos = new List<Plato>();
            string nombrePlato;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MENÚ DEL RESTAURANTE");
            Console.WriteLine();
            Console.WriteLine("-Plato de Camarones Empanizados = Q100.00");
            Console.WriteLine("-Porción de pastel de chocolate = Q20.00");
            Console.WriteLine("-Crepas = Q30.00");
            Console.WriteLine("-Hamburguesa = Q40.00");
            Console.WriteLine("-Porción de Pizza = Q10.00");
            Console.WriteLine("-Desayuno Tradicional = Q30.00");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Ingrese el nombre del plato (o 'fin' para terminar): ");
                nombrePlato = Console.ReadLine();

                if (nombrePlato.ToLower() != "fin")
                {
                    Console.Write("Ingrese el precio del plato: Q");
                    double precioPlato = Convert.ToDouble(Console.ReadLine());
                    platos.Add(new Plato(nombrePlato, precioPlato));
                }
            } while (nombrePlato.ToLower() != "fin");

            Reserva nuevaReserva = new Reserva(siguienteNumeroReserva++, fechaHora, cliente, platos);
            reservas.Add(nuevaReserva);
            Console.WriteLine("Reserva registrada exitosamente.\n");
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Formato de fecha o precio no válido.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocurrió un error al registrar la reserva: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void MostrarDetallesClientes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("DETALLES DE CLIENTES");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        foreach (var cliente in clientes)
        {
            Console.WriteLine(cliente);
        }
        Console.WriteLine();
    }

    static void MostrarDetallesReservas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("DETALLES DE RESERVAS");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        foreach (var reserva in reservas)
        {
            Console.WriteLine(reserva);
        }
        Console.WriteLine();
    }

    static void BuscarCliente()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("BUSCAR A CLIENTE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Ingrese el nombre del cliente a buscar: ");
            string nombre = Console.ReadLine();
            Cliente cliente = clientes.FirstOrDefault(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (cliente != null)
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(cliente);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cliente no encontrado");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocurrió un error al buscar el cliente: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void BuscarReserva()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("BUSCAR RESERVAS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Ingrese el número de la reserva a buscar: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Reserva reserva = reservas.FirstOrDefault(r => r.Numero == numero);

            if (reserva != null)
            {
                Console.WriteLine("Reserva encontrada:");
                Console.WriteLine(reserva);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Reserva no encontrada.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Número de reserva no válido.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocurrió un error al buscar la reserva: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(); 
            Console.Clear();
        }
    }
}
    