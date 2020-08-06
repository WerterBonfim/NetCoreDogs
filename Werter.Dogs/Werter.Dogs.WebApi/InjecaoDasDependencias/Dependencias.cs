using Microsoft.Extensions.DependencyInjection;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Infra.Contexto;
using Werter.Dogs.Infra.Repositorio;
using Werter.Dogs.Servicos.ServicosDeUsuario;

namespace Werter.Dogs.WebApi.InjecaoDasDependencias
{
    public class Dependencias
    {
        public static void LidarComAsDepencias(IServiceCollection services)
        {
            // Serviços
            services.AddTransient<LidarComCriacaoDeUsuario, LidarComCriacaoDeUsuario>();

            // Repositorio
            services.AddTransient<DogsContexto, DogsContexto>();
            services.AddTransient<IRepositorioCliente, UsuarioRepositorio>();
        }
    }
}
