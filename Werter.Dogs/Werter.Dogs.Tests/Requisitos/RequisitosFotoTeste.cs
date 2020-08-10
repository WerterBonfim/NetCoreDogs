using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Tests.Requisitos
{
    [TestFixture]
    public class RequisitosFotoTeste
    {
        [Test, Category("Foto")]
        public void DeveCadastrarUmaFotoComSucesso()
        {
            var repositorio = Substitute.For<IRepositorioFoto>();

            var requisitos = new RequisitosParaCadastrarFoto
            {
                Idade = 3,
                Nome = "doogs",
                Peso = 3,
                UsuarioId = Guid.NewGuid()
            };

            requisitos.EValido().Should().BeTrue();
            requisitos.ListaErros().Should().HaveCount(0);
        }
        
        [Test, Category("Foto")]
        public void DeveRetornar4NotificacoesPoisOsDadosSaoObrigatorios()
        {
            var repositorio = Substitute.For<IRepositorioFoto>();

            var requisitos = new RequisitosParaCadastrarFoto
            {
                Idade = 0,
                Nome = "",
                Peso = 0,
                UsuarioId = Guid.Empty
            };

            requisitos.EValido().Should().BeFalse();
            requisitos.ListaErros().Should().HaveCount(4);
        }
        
        
        [Test, Category("Foto")]
        public void DevaAtualizarUmaFotoComSucesso()
        {
            var repositorio = Substitute.For<IRepositorioFoto>();

            var requisitos = new RequisitosParaAtualizarFoto
            {
                Idade = 10,
                Nome = "nome do cachorro",
                Peso = 10,
                Id = Guid.NewGuid()
            };

            requisitos.EValido().Should().BeTrue();
            requisitos.ListaErros().Should().HaveCount(0);
        }
    }
}