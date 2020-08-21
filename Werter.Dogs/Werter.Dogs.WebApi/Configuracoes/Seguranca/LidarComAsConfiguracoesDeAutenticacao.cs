using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Werter.Dogs.WebApi.Seguranca
{
    public class LidarComAsConfiguracoesDeAutenticacao
    {
        public static void ConfigurarAutenticacao(IServiceCollection services, IConfiguration configuration)
        {
            var configuracaoDeAutenticacao = new ConfiguracaoDeAutenticacao();
            services.AddSingleton(configuracaoDeAutenticacao);

            var configuracaoDeToken = new ConfiguracaoDoToken();

            new ConfigureFromConfigurationOptions<ConfiguracaoDoToken>(
                    configuration
                        .GetSection("TokenConfigurations"))
                .Configure(configuracaoDeToken);

            services.AddSingleton(configuracaoDeToken);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                // x.Events = new JwtBearerEvents
                // {
                //     OnAuthenticationFailed = (contexto) =>
                //     {
                //         contexto.Fail("werter");
                //         return contexto.Request.
                //     }
                //     
                // };


                var parametrosDeValidacao = x.TokenValidationParameters;
                var key = configuracaoDeAutenticacao.Key.ToString();
                Console.WriteLine(key);

                parametrosDeValidacao.IssuerSigningKey = configuracaoDeAutenticacao.Key;
                parametrosDeValidacao.ValidAudience = configuracaoDeToken.Audience;
                parametrosDeValidacao.ValidIssuer = configuracaoDeToken.Issuer;
                parametrosDeValidacao.ValidateIssuerSigningKey = true;
                parametrosDeValidacao.ClockSkew = TimeSpan.Zero;
            });
        }
    }
}