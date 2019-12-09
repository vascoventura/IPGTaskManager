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
        public int CargoId { get; set; }


        [Required(ErrorMessage = "Por favor, introduza o tipo de cargo a designar")]
        public string NomeCargo { get; set; }

        
        [Required(ErrorMessage = "Por favor, introduza a descrição do cargo")]
        public string Descricao { get; set; }


    }
}
