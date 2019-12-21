using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public DbSet<IPGManager.Models.Horario> Horario { get; set; }

        public DbSet<IPGManager.Models.Tarefa> Tarefa { get; set; }
        public DbSet<IPGManager.Models.Professor> Professor { get; set; }
        public DbSet<IPGManager.Models.GeneroLista> Generos { get; set; }
    }
}
