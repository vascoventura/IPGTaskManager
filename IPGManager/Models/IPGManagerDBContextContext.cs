using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IPGManager.Models
{
    public partial class IPGManagerDBContextContext : DbContext
    {
        public IPGManagerDBContextContext()
        {
        }

        public IPGManagerDBContextContext(DbContextOptions<IPGManagerDBContextContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professor> Professor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IPGManagerDBContext;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasIndex(e => e.DepartamentoId);

                entity.Property(e => e.ProfessorId).HasColumnName("ProfessorID");

                entity.Property(e => e.Pnome)
                    .IsRequired()
                    .HasColumnName("PNome");

                entity.Property(e => e.Unome)
                    .IsRequired()
                    .HasColumnName("UNome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
