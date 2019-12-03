using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }

        public string NomeCargo { get; set; }


        public string Descricao { get; set; }
    }
}
