using ComandasApi.Models;
using ComandasApi.Services;

namespace ComandasApi.Menus
{
    public class ReporteDiarioMenu
    {
        private readonly ComandaService comandaService;

        public ReporteDiarioMenu()
        {
            comandaService = new ComandaService();
        }

        public void MostrarReporteDiario()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("- Reporte Diario de Comandas:");
            Console.WriteLine("================================================");
            Console.WriteLine();

            var comandas = comandaService.GetAllComandas();
            var comandasHoy = comandas.Where(c => c.Fecha.Date == DateTime.Now.Date).ToList();

            if (comandasHoy.Count == 0)
            {
                Console.WriteLine("No hay comandas registradas para el día de hoy.");
            }
            else
            {
                MostrarComandas(comandasHoy);
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarComandas(List<Comanda> comandas)
        {
            foreach (var comanda in comandas)
            {
                Console.WriteLine($"ID: {comanda.Id}, Mesa: {comanda.Mesa}, Platillo: {comanda.Platillo}, Cantidad Platillo: {comanda.CantidadPlatillo}, Bebestible: {comanda.Bebestible}, Cantidad Bebestible: {comanda.CantidadBebestible}, Postre: {comanda.Postre}, Cantidad Postre: {comanda.CantidadPostre}, Fecha: {comanda.Fecha}");
            }
        }
    }
}
