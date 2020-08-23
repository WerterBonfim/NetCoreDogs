using Microsoft.EntityFrameworkCore.Design;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra
{
    /// <summary>
    /// Classe de ajuda para a estratégia de migrations. O EFCore vai usar ele internamente
    /// </summary>
    public class DogsContextFactory : IDesignTimeDbContextFactory<DogsContexto>
    {
        public DogsContexto CreateDbContext(string[] args)
        { 
            // Banco que esta no Docker
            var stringDeConexaoDocker = "Server=localhost,1433;Database=DB_Dogs;User Id=sa;Password=!123Dogs;";
            return new DogsContexto(stringDeConexaoDocker);
        }
    }
}