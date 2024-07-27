namespace Examen2.Dtos.Prestamos
{
    public class CreatePrestamoDto
    {
        public Guid IdPrestamo { get; set; }
        public float Monto { get; set; }
        public float Interes { get; set; }
        public int Plazo { get; set; }
        public DateTime FechaDesombolso { get; set; }
        public Guid IdCliente { get; set; }
    }
}
