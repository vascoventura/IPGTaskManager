using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Cargo
    {
        
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o nome")]
        public string NomeCargo { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o nivel do cargo")]
        public int NivelCargo { get; set; }

        public ICollection<Funcionario> Funcionarios;

        public ICollection<Tarefa> Tarefas; 

    }
}
