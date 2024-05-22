namespace ComandasApi.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Platillo { get; set; }
        public string Bebestible { get; set; } 
        public string Postre { get; set; } 
        public int CantidadPlatillo { get; set; }
        public int CantidadBebestible { get; set; } 
        public int CantidadPostre { get; set; } 
        public DateTime Fecha { get; set; }
    }
}
