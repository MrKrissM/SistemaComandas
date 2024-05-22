using ComandasApi.Models;
using System.Globalization;


namespace ComandasApi.Services
{
    public class ComandaService
    {
        private readonly string filePath = "comandas.txt";

        public List<Comanda> GetAllComandas()
        {
            var comandas = new List<Comanda>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    var comanda = new Comanda
                    {
                        Id = int.Parse(parts[0]),
                        Mesa = parts[1],
                        Platillo = parts[2],
                        Bebestible = parts[3],
                        Postre = parts[4],
                        CantidadPlatillo = int.Parse(parts[5]),
                        CantidadBebestible = int.Parse(parts[6]),
                        CantidadPostre = int.Parse(parts[7]),
                        Fecha = DateTime.Parse(parts[8], null, DateTimeStyles.RoundtripKind)
                    };
                    comandas.Add(comanda);
                }
            }
            return comandas;
        }

        public Comanda GetComanda(int id)
        {
            return GetAllComandas().FirstOrDefault(c => c.Id == id);
        }

        public void AddComanda(Comanda comanda)
        {
            var comandas = GetAllComandas();
            comanda.Id = comandas.Any() ? comandas.Max(c => c.Id) + 1 : 1;
            comandas.Add(comanda);
            SaveAllComandas(comandas);
        }

        public void UpdateComanda(Comanda comanda)
        {
            var comandas = GetAllComandas();
            var index = comandas.FindIndex(c => c.Id == comanda.Id);
            if (index >= 0)
            {
                comandas[index] = comanda;
                SaveAllComandas(comandas);
            }
        }

        public void DeleteComanda(int id)
        {
            var comandas = GetAllComandas();
            var comanda = comandas.FirstOrDefault(c => c.Id == id);
            if (comanda != null)
            {
                comandas.Remove(comanda);
                SaveAllComandas(comandas);
            }
        }

        private void SaveAllComandas(List<Comanda> comandas)
        {
            var lines = comandas.Select(c => $"{c.Id};{c.Mesa};{c.Platillo};{c.Bebestible};{c.Postre};{c.CantidadPlatillo};{c.CantidadBebestible};{c.CantidadPostre};{c.Fecha.ToString("o")}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
