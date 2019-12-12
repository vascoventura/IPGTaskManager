using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IPGManager.Models
{
    public partial class Professor
    {
        public int ProfessorId { get; set; }
        public string Pnome { get; set; }
        public string Unome { get; set; }
        public string Contacto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string genero { get; set; }
        public int? DepartamentoId { get; set; }
    }
}
