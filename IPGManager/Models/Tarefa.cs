using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Tarefa
    {
        [Required]
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o nome da tarefa")]

        public string NomeTarefa { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a descrição da tarefa")]
        public string DescricaoTarefa { get; set; }

        [Required(ErrorMessage = "Por favor, introduza quando a tarefa foi realizada")]
        public DateTime DataTarefa { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o cargo a que a tarefa se destina")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public ICollection<TarFunc> TarFunc;


    }
}
