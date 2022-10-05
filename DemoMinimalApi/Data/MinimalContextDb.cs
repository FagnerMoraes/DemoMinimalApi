using DemoMinimalApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMinimalApi.Data
{
    public class MinimalContextDb : DbContext
    {
        public MinimalContextDb(DbContextOptions<MinimalContextDb> options) :base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Fornecedor>()
                .ToTable("TB_Fornecedor");

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            base.OnModelCreating(modelBuilder);

        }
    }
}
