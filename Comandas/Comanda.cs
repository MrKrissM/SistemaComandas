namespace ComandasApi.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Platillo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
