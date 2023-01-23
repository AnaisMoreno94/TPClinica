using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WSClinica.Models
{
    [Table("Medico")]
    public class Medico
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }

        public int Matricula { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        public int EspecialidadId { get; set; }

        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }

        public List<Paciente> Pacientes { get; set; }
    }
}
