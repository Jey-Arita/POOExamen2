using Examen2.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Dtos.Prestamos
{
    public class PrestamoDto
    {
        public Guid IdPrestamo { get; set; }
        public float Monto { get; set; }
        public float Interes { get; set; }
        public int Plazo { get; set; }
        public DateTime FechaDesombolso { get; set; }
        public Guid IdCliente { get; set; }
    }
}
