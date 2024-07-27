using Examen2.Dtos.Clientes;
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

        [Column("monto")]
        public float Monto { get; set; }


        [Column("interes")]
        public float Interes { get; set; }

        [Column("plaza")]
        public int Plazo { get; set; }


        [StringLength(100)]
        [Column("fecha_desembolso")]
        public DateTime FechaDesombolso { get; set; }

        [Required]
        [Column("id_autor")]
        public Guid IdCliente { get; set; }
        [ForeignKey(nameof(IdCliente))]
        public virtual ClienteEntity Cliente { get; set; }
        //public ClienteDto Cliente { get; set; }
    }
}
