using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Werter.Dogs.WebApi.Configuracoes;
using Werter.Dogs.WebApi.InjecaoDasDependencias;
using Werter.Dogs.WebApi.Seguranca;

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

            Dependencias.LidarComAsDepencias(services);
            
            
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            Dependencias.LidarComArquivoEstaticos(app, env);
            
            app.UseCors();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}