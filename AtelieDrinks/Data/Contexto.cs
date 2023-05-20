using AtelieDrinks.Models;
using Microsoft.EntityFrameworkCore;

namespace AtelieDrinks.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Base_alcoolica> Base_Alcoolica { get; set; }
        public DbSet<Custo_deslocamento> Custo_Deslocamento { get; set; }
        public DbSet<Custo_operacional> Custo_operacional { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Ficha_tecnica> Ficha_tecnica { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Orcamento> Orcamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base_alcoolica>()
                .HasKey(d => d.id_base_alcoolica);

            modelBuilder.Entity<Custo_deslocamento>()
                .HasKey(d => d.id_taxa_deslocamento);

            modelBuilder.Entity<Custo_operacional>()
                .HasKey(d => d.id_custo_operacional);

            modelBuilder.Entity<Deposito>()
                .HasKey(d => d.id_item);

            modelBuilder.Entity<Drinks>()
                .HasKey(d => d.id_drink);

            modelBuilder.Entity<Ficha_tecnica>()
                .HasKey(d => d.id_ficha);

            modelBuilder.Entity<Historico>()
                .HasKey(d => d.id_historico);

            modelBuilder.Entity<Insumos>()
                .HasKey(d => d.id_insumo);

            modelBuilder.Entity<Marca>()
                .HasKey(d => d.id_marca);

            modelBuilder.Entity<Orcamento>()
                .HasKey(d => d.id_orcamento);

        }
    }
}