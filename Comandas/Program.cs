using ComandasApi.Menus;

class Program
{
    static void Main()
    {
        MenuPrincipal();
    }

    static void MenuPrincipal()
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
            Console.WriteLine("2. Ver reporte diario");
            Console.WriteLine("3. Salir");
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
                    var reporteDiarioMenu = new ReporteDiarioMenu();
                    reporteDiarioMenu.MostrarReporteDiario();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }

        } while (opcion != 3);
    }
}
