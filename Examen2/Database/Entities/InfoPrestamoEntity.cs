using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Database.Entities
{
    public class InfoPrestamoEntity
    {
        [Key]
        [Required]
        [Column("id_amortizacion")]
        public Guid IdAmortizacion { get; set; }

        [Required]
        [Column("id_prestamo")]
        public Guid IdPrestamo { get; set; }

        [ForeignKey(nameof(IdPrestamo))]
        public PrestamoEntity Prestamo { get; set; }

        [Column("no_cuota")]
        public int NoCuota { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("dias")]
        public int Dias { get; set; }

        [Column("interes")]
        public float Interes { get; set; }

        [Column("abono")]
        public float Abono { get; set; }

        [Column("cuota_sin_svds")]
        public float CuotaSinSVSD { get; set; }

        [Column("cuota_con_svds")]
        public float CuotaConSVSD { get; set; }

        [Column("saldo_principal")]
        public float SaldoPrincipal { get; set; }
    }
}
