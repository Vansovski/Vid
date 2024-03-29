using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class DataContext: DbContext
    {
         public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet <Filme> Filmes { get; set; }
        
        public DbSet <Cliente> Clientes { get; set; }

        public DbSet <ClienteFilme> ClientesFilmes { get; set; }

        public DbSet <MembroTipo> MembroTipos { get; set; }

        public DbSet <Genero> Generos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteFilme>()
                .HasKey(CF => new{CF.ClienteId,CF.FilmeId});
            /*

            //Processo de Seeding
            modelBuilder.Entity<MembroTipo>().HasData(
                new MembroTipo { Id = 1, SignUpFee = 1, DuracaoMeses = "First post", Desconto = "Test 1" });
            */
            base.OnModelCreating(modelBuilder);
        }
        
    }
}