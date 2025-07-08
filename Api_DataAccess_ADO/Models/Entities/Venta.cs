namespace Api_DataAccess_ADO.Models.Entities
{
    public class Venta
    {
        public int Id { get; set; }

        public string Producto { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal TotalGanancia { get; set; }

        public string? CreadoPor { get; set; }

        public DateTime? CreadoEn { get; set; }

        public string? ActualizadoPor { get; set; }

        public DateTime? ActualizadoEn { get; set; }
    }
}
