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

        public DateTime HInicio { get; set; }

        public DateTime HInicioIntervalo { get; set; }

        public DateTime HFimIntervalo { get; set; }

        public DateTime HFim { get; set; }

        ICollection<Funcionario> Funcionarios;
    }
}
