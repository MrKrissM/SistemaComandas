using ComandasApi.Models;
using ComandasApi.Services;

namespace ComandasApi.Menus
{
    public class ComandaMenu
    {
        private readonly ComandaService comandaService;

        public ComandaMenu()
        {
            comandaService = new ComandaService();
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("- Gestión de Comandas:");
                Console.WriteLine("================================================");
                Console.WriteLine();
                Console.WriteLine("1. Crear una nueva comanda");
                Console.WriteLine("2. Ver una comanda");
                Console.WriteLine("3. Ver todas las comandas");
                Console.WriteLine("4. Actualizar una comanda");
                Console.WriteLine("5. Eliminar una comanda");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Ingrese el número de la opción deseada: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        CrearComanda();
                        break;
                    case 2:
                        VerComanda();
                        break;
                    case 3:
                        VerTodasLasComandas();
                        break;
                    case 4:
                        ActualizarComanda();
                        break;
                    case 5:
                        EliminarComanda();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                        break;
                }

            } while (opcion != 6);
        }

        private void VerTodasLasComandas()
        {
            var comandas = comandaService.GetAllComandas();
            foreach (var comanda in comandas)
            {
                Console.WriteLine($"ID: {comanda.Id}, Mesa: {comanda.Mesa}, Platillo: {comanda.Platillo}, Cantidad Platillo: {comanda.CantidadPlatillo}, Bebestible: {comanda.Bebestible}, Cantidad Bebestible: {comanda.CantidadBebestible}, Postre: {comanda.Postre}, Cantidad Postre: {comanda.CantidadPostre}, Fecha: {comanda.Fecha}");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerComanda()
        {
            Console.Write("Ingrese el ID de la comanda: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var comanda = comandaService.GetComanda(id);
                if (comanda != null)
                {
                    Console.WriteLine($"ID: {comanda.Id}, Mesa: {comanda.Mesa}, Platillo: {comanda.Platillo}, Cantidad Platillo: {comanda.CantidadPlatillo}, Bebestible: {comanda.Bebestible}, Cantidad Bebestible: {comanda.CantidadBebestible}, Postre: {comanda.Postre}, Cantidad Postre: {comanda.CantidadPostre}, Fecha: {comanda.Fecha}");
                }
                else
                {
                    Console.WriteLine("Comanda no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void CrearComanda()
        {
            var comanda = new Comanda();
            Console.Write("Ingrese la mesa: ");
            comanda.Mesa = Console.ReadLine();

            Console.Write("Ingrese el platillo: ");
            comanda.Platillo = Console.ReadLine();
            Console.Write("Ingrese la cantidad de platillos: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadPlatillo))
            {
                Console.WriteLine("Cantidad de platillos no válida.");
                return;
            }
            comanda.CantidadPlatillo = cantidadPlatillo;

            Console.Write("¿Desea agregar un bebestible? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Ingrese el bebestible: ");
                comanda.Bebestible = Console.ReadLine();
                Console.Write("Ingrese la cantidad de bebestibles: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidadBebestible))
                {
                    Console.WriteLine("Cantidad de bebestibles no válida.");
                    return;
                }
                comanda.CantidadBebestible = cantidadBebestible;
            }

            Console.Write("¿Desea agregar un postre? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Ingrese el postre: ");
                comanda.Postre = Console.ReadLine();
                Console.Write("Ingrese la cantidad de postres: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidadPostre))
                {
                    Console.WriteLine("Cantidad de postres no válida.");
                    return;
                }
                comanda.CantidadPostre = cantidadPostre;
            }

            comanda.Fecha = DateTime.Now;
            comandaService.AddComanda(comanda);
            Console.WriteLine("Comanda creada exitosamente.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void ActualizarComanda()
        {
            Console.Write("Ingrese el ID de la comanda a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var comanda = comandaService.GetComanda(id);
                if (comanda != null)
                {
                    Console.WriteLine($"ID: {comanda.Id}, Mesa: {comanda.Mesa}, Platillo: {comanda.Platillo}, Cantidad Platillo: {comanda.CantidadPlatillo}, Bebestible: {comanda.Bebestible}, Cantidad Bebestible: {comanda.CantidadBebestible}, Postre: {comanda.Postre}, Cantidad Postre: {comanda.CantidadPostre}, Fecha: {comanda.Fecha}");

                    Console.Write("Ingrese la nueva mesa (deje vacío para no cambiar): ");
                    var mesa = Console.ReadLine();
                    if (!string.IsNullOrEmpty(mesa))
                    {
                        comanda.Mesa = mesa;
                    }

                    Console.Write("Ingrese el nuevo platillo (deje vacío para no cambiar): ");
                    var platillo = Console.ReadLine();
                    if (!string.IsNullOrEmpty(platillo))
                    {
                        comanda.Platillo = platillo;
                    }

                    Console.Write("Ingrese la nueva cantidad de platillos (deje vacío para no cambiar): ");
                    var cantidadPlatilloStr = Console.ReadLine();
                    if (int.TryParse(cantidadPlatilloStr, out int cantidadPlatillo))
                    {
                        comanda.CantidadPlatillo = cantidadPlatillo;
                    }

                    Console.Write("Ingrese el nuevo bebestible (deje vacío para no cambiar): ");
                    var bebestible = Console.ReadLine();
                    if (!string.IsNullOrEmpty(bebestible))
                    {
                        comanda.Bebestible = bebestible;
                    }

                    Console.Write("Ingrese la nueva cantidad de bebestibles (deje vacío para no cambiar): ");
                    var cantidadBebestibleStr = Console.ReadLine();
                    if (int.TryParse(cantidadBebestibleStr, out int cantidadBebestible))
                    {
                        comanda.CantidadBebestible = cantidadBebestible;
                    }

                    Console.Write("Ingrese el nuevo postre (deje vacío para no cambiar): ");
                    var postre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(postre))
                    {
                        comanda.Postre = postre;
                    }

                    Console.Write("Ingrese la nueva cantidad de postres (deje vacío para no cambiar): ");
                    var cantidadPostreStr = Console.ReadLine();
                    if (int.TryParse(cantidadPostreStr, out int cantidadPostre))
                    {
                        comanda.CantidadPostre = cantidadPostre;
                    }

                    comandaService.UpdateComanda(comanda);
                    Console.WriteLine("Comanda actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Comanda no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void EliminarComanda()
        {
            Console.Write("Ingrese el ID de la comanda a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var comanda = comandaService.GetComanda(id);
                if (comanda != null)
                {
                    comandaService.DeleteComanda(id);
                    Console.WriteLine("Comanda eliminada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Comanda no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
