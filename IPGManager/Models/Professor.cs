using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IPGManager.Models
{
    public class Professor
    {

        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o primeiro nome")]
        [StringLength (50, ErrorMessage = "O nome é muito longo")]
        public string Nome { get; set; }

        [Required]
        public string Contacto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public int DepartamentoId { get; set; }

        [Required]
        public Departamento Departamento { get; set; }

        [Required]
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
    }
}
