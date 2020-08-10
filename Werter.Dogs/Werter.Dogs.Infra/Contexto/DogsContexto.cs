using Microsoft.EntityFrameworkCore;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Infra.Contexto
{
    public class DogsContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringDeConexao = "Server=localhost,1433;Database=DB_Dogs;User Id=sa;Password=!007Dogs;";
            optionsBuilder.UseSqlServer(stringDeConexao);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            //this.Database.EnsureCreated();
            modelBuilder.ApplyConfiguration(new Mapeamento.UsuarioMap());
            modelBuilder.ApplyConfiguration(new Mapeamento.FotoMap());
            modelBuilder.ApplyConfiguration(new Mapeamento.ComentarioMap());
        }
    }
}
