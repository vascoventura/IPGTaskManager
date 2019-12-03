using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class IPGManagerDBContext : DbContext
    {
        public IPGManagerDBContext(DbContextOptions<IPGManagerDBContext> options) : base(options)
        {
        }

        public DbSet<IPGManager.Models.Funcionario> Funcionarios { get; set; }

        public DbSet<IPGManager.Models.Cargo> Cargos { get; set; }

        public DbSet<IPGManager.Models.Departamento> Departamentos { get; set; }

        public DbSet<IPGManager.Models.Horario> Horarios { get; set; }
    }
}
