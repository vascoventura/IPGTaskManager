using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Horario
    {
        public int HorarioId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Hora de Inicio")]
        [DataType(DataType.Time)]
        public DateTime HInicio { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Hora de Inicio de Almoço")]
        [DataType(DataType.Time)]
        public DateTime HInicioIntervalo { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Hora de Fim de Almoço")]
        [DataType(DataType.Time)]
        public DateTime HFimIntervalo { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Hora de Fim")]
        [DataType(DataType.Time)]
        public DateTime HFim { get; set; }

        public ICollection<Funcionario> Funcionarios;
    }
}
