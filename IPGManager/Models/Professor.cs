using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IPGManager.Models
{
    public class Professor
    {

        public int ProfessorId { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o nome")]
        public string Pnome { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o Apelido")]
        public string Unome { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o Contacto")]
        public string Contacto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o Género")]
        public string genero { get; set; }
        public int? DepartamentoId { get; set; }
    }
}
