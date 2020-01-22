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

        
        [Required(ErrorMessage = "Por favor, introduza o Nome do Departamento")]
        [StringLength(50, ErrorMessage = "O nome é muito longo")]
        public string NomeDepartamento { get; set; }

        public ICollection<Professor> Professores;
    }
}
