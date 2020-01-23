using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPGManager.Models
{
    public partial class Professor
    {
        public int ProfessorId { get; set; }
        [Required( ErrorMessage = "Por favor, introduza o nome")]
        [StringLength (50, ErrorMessage = "O nome é muito longo")]
        public string Nome { get; set; }



        [RegularExpressionAttribute("^9[1236]{1}[0-9]{7}$",
        ErrorMessage = "Contato Inválido ")]
        public string Contacto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [MinAge(18)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Género")]
         
        public int GeneroId { get; set; }        
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

    }
}
