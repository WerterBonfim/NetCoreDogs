using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Comentario;
using Werter.Dogs.Dominio.Requisitos.Foto;
using Werter.Dogs.Dominio.Requisitos.Usuario;
using Werter.Dogs.Infra.Contexto;
using Werter.Dogs.Infra.Repositorio;
using Werter.Dogs.Servicos.Querys;
using Werter.Dogs.Servicos.Querys.Interfaces;
using Werter.Dogs.Servicos.ServicosDeComentario;
using Werter.Dogs.Servicos.ServicosDeFoto;
using Werter.Dogs.Servicos.ServicosDeUsuario;
using Werter.Dogs.WebApi.Configuracoes;

namespace Werter.Dogs.WebApi.Configuracoes.InjecaoDasDependencias
{
    public class Dependencias
    {
        public static void LidarComAsDepencias(IServiceCollection services, ConfiguracaoAplicacao configuracaoAplicacao)
        {
            // Repositorio
            
            services.AddTransient<DogsContexto, DogsContexto>(x =>
                new DogsContexto(configuracaoAplicacao.StringDeConexao));
            services.AddTransient<IRepositorioCliente, UsuarioRepositorio>();
            services.AddTransient<IRepositorioFoto, FotoRepositorio>();
            services.AddTransient<IRepositorioComentario, ComentarioRepositorio>();

            // Serviços
            services.AddTransient<ITarefa<RequisitosParaCadastrarFoto>, LidarComCadastroDeFoto>();
            services.AddTransient<ITarefa<RequisitosParaAtualizarFoto>, LidarComAtualizacaoDeFoto>();
            services.AddTransient<ITarefa<RequisitosParaExcluirFoto>, LidarComExcluirFoto>();
            services.AddTransient<ITarefa<RequisitosParaIncrementarAcesso>, LidarComIncrementoDeAcessos>();

            services.AddTransient<ITarefa<RequisitosParaCriarUsuario>, LidarComCriacaoDeUsuario>();
            services.AddTransient<ITarefa<RequisitosParaAtualizarUsuario>, LidarComAtualizacaoDeUsuario>();
            services.AddTransient<ITarefa<RequisitosParaLogin>, LidarComLoginDoUsuario>();

            services.AddTransient<ITarefa<RequisitosParaCriarComentario>, LidarComCriacaoDeComentario>();
            services.AddTransient<ITarefa<RequisitosParaAlterarComentario>, LidarComAlteracaoDeComentario>();
            services.AddTransient<ITarefa<RequisitosParaExcluirComentario>, LidarComExcluirComentario>();

            // Querys
            services.AddTransient<IComentarioQuery, ComentarioQuerys>();
            services.AddTransient<IFeedQuery, FeedQuery>();
            services.AddTransient<IFotoQuery, FotoQuery>();


            services.AddTransient<ServisosDoUsuario, ServisosDoUsuario>();
            services.AddTransient<ServicosDeFotos, ServicosDeFotos>();
            services.AddTransient<ServicosDeComentario, ServicosDeComentario>();
        }

        public static void LidarComArquivoEstaticos(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var config = app.ApplicationServices.GetService<ConfiguracaoAplicacao>();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(config.DiretorioImagens),
                RequestPath = "/imagens"
            });

            if (env.IsDevelopment())
                app.UseDirectoryBrowser(new DirectoryBrowserOptions
                {
                    FileProvider = new PhysicalFileProvider(config.DiretorioImagens),
                    RequestPath = "/imagens"
                });
        }
    }
}