using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IPGManager.Models;
using System;

namespace IPGManager.Models
{
    public class IPGManagerDBContext : DbContext
    {

       
        public IPGManagerDBContext(DbContextOptions<IPGManagerDBContext> options) : base(options)
        {
        }

        public DbSet<IPGManager.Models.Funcionario> Funcionario { get; set; }

        public DbSet<IPGManager.Models.Cargo> Cargo { get; set; }

        public DbSet<IPGManager.Models.Departamento> Departamento { get; set; }

        public DbSet<IPGManager.Models.Tarefa> Tarefa { get; set; }
        public DbSet<IPGManager.Models.Professor> Professor { get; set; }
        public DbSet<IPGManager.Models.Genero> Genero { get; set; }
        public DbSet<IPGManager.Models.Login> Login { get; set; }
        public DbSet<IPGManager.Models.TarFunc> TarFunc { get; set; }
        public DbSet<IPGManager.Models.TFC> TFC { get; set; }

    }
}