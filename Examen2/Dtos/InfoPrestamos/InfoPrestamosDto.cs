using Examen2.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Dtos.InfoPrestamos
{
    public class InfoPrestamosDto
    {
        public Guid IdAmortizacion { get; set; }
        public Guid IdPrestamo { get; set; }
        public int NoCuota { get; set; }
        public DateTime Fecha { get; set; }
        public int Dias { get; set; }
        public decimal Interes { get; set; }
        public decimal Abono { get; set; }
        public decimal CuotaSinSVSD { get; set; }
        public decimal CuotaConSVSD { get; set; }
        public decimal SaldoPrincipal { get; set; }
    }
}
