using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        
        [Required(ErrorMessage = "Por favor, introduza o nome")]
        public string NomeDepartamento { get; set; }

        ICollection<Funcionario> Funcionarios;

        ICollection<Professor> Professores ;
    }
}
