using Microsoft.EntityFrameworkCore;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Infra.Mapeamento;

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
            optionsBuilder
                //.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(stringDeConexao);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.Database.EnsureCreated();
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new FotoMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
        }
    }
}