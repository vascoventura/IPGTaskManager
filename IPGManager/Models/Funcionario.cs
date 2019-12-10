using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Funcionario
    {
        
        [Key]
        public int FuncionarioId { get; set; }


        [Required(ErrorMessage = "Por favor, introduza o nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, introduza a data")]
        public DateTime DataNascimento { get; set; }


        
        [Required(ErrorMessage = "Por favor, introduza o género do funcionário (M/F)")]
        [RegularExpression("[M] | [F] | [m] | [f]",
        ErrorMessage = "Por favor, introduza o género do funcionário (M/F)")]
        public char Genero { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }


        public int HorarioId { get; set; }
    }
}
