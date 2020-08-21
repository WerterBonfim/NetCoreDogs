using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.WebApi.Configuracoes
{
    public static class PrepararDb
    {
        public static void RodarMigrationsInicial(IApplicationBuilder app)
        {
            
            using (var scopo = app.ApplicationServices.CreateScope())
            {
                RodarMigrations(scopo.ServiceProvider.GetService<DogsContexto>());
            }
        }

        private static void RodarMigrations(DogsContexto context)
        {
            Console.WriteLine("Verificando se o banco já existe");
            if (context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                Console.WriteLine("Banco de dados já existe");
                return;
            }
                

            Console.WriteLine("Iniciando migrations");
            if (context.Database.GetMigrations().Any())
                context.Database.Migrate();

        }
    }
}