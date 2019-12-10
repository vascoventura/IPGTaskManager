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

        [Required]
        public string NomeCargo { get; set; }

        [Required]
        public string Descricao { get; set; }


        public int NivelCargo { get; set; }
    }
}
