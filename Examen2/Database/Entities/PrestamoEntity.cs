using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.Database.Entities
{
    [Table("datos_prestamo", Schema = "dbo")]
    public class PrestamoEntity
    {
        [Key]
        [Required]
        [Column("id_prestamo")]
        public Guid IdPrestamo { get; set; }

        [StringLength(100)]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("duracion_prestamo")]
        public float DuracionPrestamo { get; set; }

        [Column("interes")]
        public float Interes { get; set; }

        [Column("abono")]
        public float Abono { get; set; }

        [Column("cuotas")]
        public float Cuotas { get; set; }

        [Column("capital_total")]
        public float CapitalTotal { get; set; }
    }
}
