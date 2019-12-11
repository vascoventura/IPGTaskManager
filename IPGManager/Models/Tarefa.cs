using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Tarefa
    {
        [Key]
        public int TarefaId { get; set; }
        [Required(ErrorMessage ="...")]
        
        public string NomeTarefa { get; set; }
        public string DescricaoTarefa { get; set; }
        public DateTime DataTarefa { get; set; }




    }
}
