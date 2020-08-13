using System;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;
using Werter.Dogs.Servicos.ServicosDeFoto;

namespace Werter.Dogs.Tests.Servicos
{
    [TestFixture]
    public class ServicosDaFotoTeste
    {
        [Test]
        [Category("Foto")]
        public void DeveCadastrarUmaFotoComSucesso()
        {
            var repositorioFoto = Substitute.For<IRepositorioFoto>();

            var requisitos = new RequisitosParaCadastrarFoto
            {
                Idade = 10,
                Nome = "nome do cachorro",
                Peso = 10,
                UsuarioId = Guid.NewGuid()
            };

            requisitos.EValido().Should().BeTrue();
            requisitos.ListaErros().Should().HaveCount(0);

            var servico = new LidarComCadastroDeFoto(repositorioFoto);


            var foto = new Foto(requisitos.Nome, requisitos.Peso, requisitos.Idade, requisitos.UsuarioId);
            repositorioFoto.Inserir(foto);

            var resultado = servico.LidarCom(requisitos);
            resultado.Sucesso.Should().BeTrue();
        }

        [Test]
        [Category("Foto")]
        public void DeveExcluirUmaFotoComSucesso()
        {
            var repositorio = Substitute.For<IRepositorioFoto>();

            var requisitos = new RequisitosParaExcluirFoto
            {
                Id = Guid.NewGuid()
            };

            requisitos.EValido().Should().BeTrue();
            requisitos.ListaErros().Should().HaveCount(0);

            var servico = new LidarComExcluirFoto(repositorio);
            repositorio.BuscarPorId(requisitos.Id).Returns(new Foto());


            var resultado = servico.LidarCom(requisitos);
            resultado.Sucesso.Should().BeTrue();
        }

        [Test]
        [Category("Foto")]
        public void ParaUmaFotoQueNaoExisteDeveRetornarErro()
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

            var servico = new LidarComAtualizacaoDeFoto(repositorio);
            repositorio.BuscarPorId(requisitos.Id).ReturnsNull();


            var resultado = servico.LidarCom(requisitos);
            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().BeEquivalentTo("Essa foto não existe");
        }
    }
}