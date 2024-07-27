using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.Database.Entities
{
    [Table("cliente", Schema = "dbo")]
    public class ClienteEntity
    {
        [Key]
        [Required]
        [Column("id_cliente")]
        public Guid IdCliente { get; set; }

        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [StringLength(100)]
        [Column("numero_Identidad")]
        public string NumeroIdentidad { get; set; }


        //[Column("monto_prestamo")]
        //public float MontoPrestamo { get; set; }

        //[Column("plan_amortizacion")]
        //public float PlanAmortizacion { get; set; }

    }
}
