using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Werter.Dogs.WebApi.Configuracoes;
using Werter.Dogs.WebApi.Configuracoes.InjecaoDasDependencias;
using Werter.Dogs.WebApi.Configuracoes.Seguranca;


namespace Werter.Dogs.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var configuracaoAplicacao = new ConfiguracaoAplicacao();

            new ConfigureFromConfigurationOptions<ConfiguracaoAplicacao>(
                    Configuration
                        .GetSection("ConfiguracaoAplicacao"))
                .Configure(configuracaoAplicacao);

            services.AddSingleton(configuracaoAplicacao);

            LidarComAsConfiguracoesDeAutenticacao.ConfigurarAutenticacao(services, Configuration);

            Dependencias.LidarComAsDepencias(services, configuracaoAplicacao);


            services.AddMemoryCache();
            services
                .AddMiniProfiler(options => options.RouteBasePath = "/profiler")
                .AddEntityFramework();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyHeader();
                
            });

            app.UseAuthentication();
            app.UseAuthorization();

            Dependencias.LidarComArquivoEstaticos(app, env);
            app.UseMiniProfiler();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            PrepararDb.RodarMigrationsInicial(app);
        }
    }
}