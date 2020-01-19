using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Funcionario{
        
        [Key]
        public int FuncionarioId { get; set; }


        [Required(ErrorMessage = "Por favor, introduza o Nome")]
        [StringLength(50, ErrorMessage = "O nome é muito extenso")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Contacto")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, selcecione o género")]
        public int GeneroId { get; set; }        
        public string Genero { get; set; }


        [Required(ErrorMessage = "Por favor, selcecione o tipo de cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public ICollection<Tarefa> Tarefas;

    }
}
