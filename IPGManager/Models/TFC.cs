using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class TFC
    {

        public int TFCId { get; set; }

        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
