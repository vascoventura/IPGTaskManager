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
        public int IdDepartamento { get; set; }

        public string NomeDepartamento { get; set; }
    }
}
