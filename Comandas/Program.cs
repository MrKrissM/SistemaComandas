using ComandasApi.Menus;
using System;


MenuPrincipal();

void MenuPrincipal()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("- Menú Principal:");
        Console.WriteLine("================================================");
        Console.WriteLine();
        Console.WriteLine("1. Gestionar comandas");
        Console.WriteLine("2. Salir");
        Console.Write("Ingrese el número de la opción deseada: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
            continue;
        }

        switch (opcion)
        {
            case 1:
                var comandaMenu = new ComandaMenu();
                comandaMenu.MostrarMenu();
                break;
            case 2:
                Console.WriteLine("Saliendo del programa...");
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                break;
        }

    } while (opcion != 2);
}

