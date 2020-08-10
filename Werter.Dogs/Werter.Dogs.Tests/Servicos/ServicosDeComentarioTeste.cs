using System;
using NSubstitute;
using NUnit.Framework;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Tests.Servicos
{
    [TestFixture]
    public class ServicosDeComentarioTeste
    {
        [Test, Category("Comentario")]
        public void DeveCadastrarUmComentarioComSucesso()
        {
            var requisitos = new RequisitosParaAlterarComentario
            {
                UsuarioId = Guid.NewGuid(),
                FotoId = Guid.NewGuid(),
                Texto = "Esse cachoro é legal"
            };

            var repositorio = Substitute.For<IRepositorioComentario>();
            
            


        }
    }
}