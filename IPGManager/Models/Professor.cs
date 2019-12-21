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
        
        [Required(ErrorMessage = "Por favor, introduza o Apelido")]
       

        public string Contacto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o Género")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public int GeneroId { get; set; }
        public GeneroLista Genero { get; set; }
        public int? DepartamentoId { get; set; }
    }
}
