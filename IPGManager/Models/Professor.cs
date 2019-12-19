using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IPGManager.Models
{
    public partial class Professor
    {
        public int ProfessorId { get; set; }
        [Required( ErrorMessage = "Por favor, introduza o nome")]
        [StringLength (4, ErrorMessage = "O nome é muito longo")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Por favor, introduza o Apelido")]
       

        public string Contacto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o Género")]
        public string Genero { get; set; }
      
        public int? DepartamentoId { get; set; }
    }
}
