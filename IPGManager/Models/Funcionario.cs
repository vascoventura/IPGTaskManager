using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Funcionario{
        
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GeneroId { get; set; }        
        public Genero Genero { get; set; }


        
        [Required(ErrorMessage = "Por favor, selcecione o tipo de cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        
        public ICollection<Tarefa> Tarefas;

        public ICollection<TarFunc> TarFunc;

    }
}
