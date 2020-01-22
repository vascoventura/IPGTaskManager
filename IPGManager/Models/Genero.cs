using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Genero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int GeneroId { get; set; }
        public String GeneroTipo { get; set; }
        

        public ICollection<Funcionario> Funcionarios { get; set; }
        
        public ICollection<Professor> professores { get; set; }

    }
}
