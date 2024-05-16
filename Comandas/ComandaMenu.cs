using ComandasApi.Models;
using ComandasApi.Services;
using System;

namespace ComandasApi.Menus
{
    public class ComandaMenu
    {
        private readonly ComandaService _comandaService;

        public ComandaMenu()
        {
            _comandaService = new ComandaService();
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
                Console.WriteLine("1. Ver todas las comandas");
                Console.WriteLine("2. Ver una comanda");
                Console.WriteLine("3. Crear una nueva comanda");
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
                        VerTodasLasComandas();
                        break;
                    case 2:
                        VerComanda();
                        break;
                    case 3:
                        CrearComanda();
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
            var comandas = _comandaService.GetAllComandas();
            foreach (var comanda in comandas)
            {
                Console.WriteLine($"ID: {comanda.Id}, Mesa: {comanda.Mesa}, Platillo: {comanda.Platillo}, Cantidad: {comanda.Cantidad}, Fecha: {comanda.Fecha}");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerComanda()
        {
            Console.Write("Ingrese el ID de la comanda: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var comanda = _comandaService.GetComanda(id);
                if (comanda != null)
                {
                    Console.WriteLine($"ID: {comanda.Id}, Mesa: {comanda.Mesa}, Platillo: {comanda.Platillo}, Cantidad: {comanda.Cantidad}, Fecha: {comanda.Fecha}");
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
            Console.Write("Ingrese la cantidad: ");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                comanda.Cantidad = cantidad;
                comanda.Fecha = DateTime.Now;
                _comandaService.AddComanda(comanda);
                Console.WriteLine("Comanda creada exitosamente.");
            }
            else
            {
                Console.WriteLine("Cantidad no válida.");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void ActualizarComanda()
        {
            Console.Write("Ingrese el ID de la comanda a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var comanda = _comandaService.GetComanda(id);
                if (comanda != null)
                {
                    Console.Write("Ingrese la nueva mesa: ");
                    comanda.Mesa = Console.ReadLine();
                    Console.Write("Ingrese el nuevo platillo: ");
                    comanda.Platillo = Console.ReadLine();
                    Console.Write("Ingrese la nueva cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int cantidad))
                    {
                        comanda.Cantidad = cantidad;
                        comanda.Fecha = DateTime.Now;
                        _comandaService.UpdateComanda(comanda);
                        Console.WriteLine("Comanda actualizada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Cantidad no válida.");
                    }
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
                _comandaService.DeleteComanda(id);
                Console.WriteLine("Comanda eliminada exitosamente.");
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
