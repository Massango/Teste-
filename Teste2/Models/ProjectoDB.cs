using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Teste2.Models
{
    public class ProjectoDB : DbContext
    {
        public ProjectoDB() {
            
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            { Database.Connection.ConnectionString = @"Server=Massango-PC;Database=Teste2Daw; uid=sa; pwd=Massango93"; }
        } 
        
        public DbSet<Categoria> Categorias { get; set; }
        
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Aluguer> Aluguer { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Actor> Actores { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Utente> Utentes { get; set; }

        public DbSet<Copia> Copias{ get; set; }
        
        


        //Comentar e fazer build uma vez, depois de feito o build tirar os comments
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Configuration>());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        }
    }
}