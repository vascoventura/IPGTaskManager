using System;
using System.Collections.Generic;

namespace IPGManager.Models
{
    public partial class Professor
    {
        public int ProfessorId { get; set; }
        public string Pnome { get; set; }
        public string Unome { get; set; }
        public string Contacto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string genero { get; set; }
        public int? DepartamentoId { get; set; }
    }
}
