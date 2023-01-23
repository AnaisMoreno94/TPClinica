using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WSClinica.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        public int Id { get; set; }

        [RegularExpression(@"^AAA\.?[0-9]{3}$", ErrorMessage = "Debe contener AAA seguido del número de habitación.")]
        public string Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }

        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }

    }
}
