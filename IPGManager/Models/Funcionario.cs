using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class Funcionario
    {
        
        [Key]
        public int FuncionarioId { get; set; }


        [Required(ErrorMessage = "Por favor, introduza o Nome")]
        [StringLength(50, ErrorMessage = "O nome é muito extenso")]
        public string Nome { get; set; }

        [Required]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        
        [Required(ErrorMessage = "Por favor, selcecione o género")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Por favor, selcecione o tipo de cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        [Required(ErrorMessage = "Por favor, selcecione o tipo de Horário do Funcionário")]
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }

    }
}
