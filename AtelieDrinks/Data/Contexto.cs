using AtelieDrinks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtelieDrinks.Data
{
    public class Contexto : IdentityDbContext<IdentityUser>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Base_alcoolica> Base_Alcoolica { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Ficha_tecnica> Ficha_tecnica { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Orcamento> Orcamento { get; set; }
        public DbSet<Numero_convidados> Numero_convidados { get; set; }
        public DbSet<Custo_deslocamento> Custo_deslocamento { get; set; }
        public DbSet<CustoOperacional> CustoOperacional { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Base_alcoolica>()
                .HasKey(d => d.id_base_alcoolica);

            modelBuilder.Entity<Deposito>()
                .HasKey(d => d.id_item);

            modelBuilder.Entity<Drinks>()
                .HasKey(d => d.IdDrink);

            modelBuilder.Entity<Ficha_tecnica>()
                .HasKey(d => d.id_ficha);

            modelBuilder.Entity<Historico>()
                .HasKey(d => d.IdHistorico);

            modelBuilder.Entity<Insumos>()
                .HasKey(d => d.IdInsumo);

            modelBuilder.Entity<Marca>()
                .HasKey(d => d.id_marca);

            modelBuilder.Entity<Orcamento>()
                .HasKey(d => d.IdOrcamento);

            modelBuilder.Entity<Numero_convidados>()
                .HasKey(d => d.numero_pessoas);

            modelBuilder.Entity<Custo_deslocamento>()
                .HasKey(d => d.IdTaxaDeslocamento);

            modelBuilder.Entity<CustoOperacional>()
                .HasKey(d => d.IdCustoOperacional);
        }
    }
}
