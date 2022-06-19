using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet <Movie> Movies { get; set; }
        
        public DbSet <Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteFilme>()
                .HasKey(CF => new{CF.ClienteId,CF.MovieId});
        
            base.OnModelCreating(modelBuilder);
        }
        
    }
}