using System;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Comentario;
using Werter.Dogs.Servicos.ServicosDeComentario;

namespace Werter.Dogs.Tests.Servicos
{
    [TestFixture]
    public class ServicosDeComentarioTeste
    {
        private static Comentario ObterComentarioFake()
        {
            var comentarioFake = new Comentario(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "qualuer coisa");
            return comentarioFake;
        }


        [Test]
        [Category("Comentario")]
        public void DeveAlterarUmComentarioComSucesso()
        {
            var comentarioFake = ObterComentarioFake();

            var requisitos = new RequisitosParaAlterarComentario
            {
                Id = comentarioFake.Id,
                Texto = "lorem ipsum"
            };

            var repositorio = Substitute.For<IRepositorioComentario>();

            repositorio.BuscarPorId(requisitos.Id).Returns(comentarioFake);

            var servico = new LidarComAlteracaoDeComentario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeTrue();
        }

        [Test]
        [Category("Comentario")]
        public void DeveCadastrarUmComentarioComSucesso()
        {
            var requisitos = new RequisitosParaCriarComentario
            {
                UsuarioId = Guid.NewGuid(),
                FotoId = Guid.NewGuid(),
                Texto = "Esse cachoro é legal"
            };

            var repositorio = Substitute.For<IRepositorioComentario>();

            var servico = new LidarComCriacaoDeComentario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeTrue();
        }

        [Test]
        [Category("Comentario")]
        public void DeveExcluirUmComentarioComSucesso()
        {
            var requisitos = new RequisitosParaExcluirComentario
            {
                Id = Guid.NewGuid()
            };

            var repositorio = Substitute.For<IRepositorioComentario>();

            var comentarioFake = ObterComentarioFake();

            repositorio.BuscarPorId(requisitos.Id).Returns(comentarioFake);

            var servico = new LidarComExcluirComentario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeTrue();
            resultado.Mensagem.Should().BeEquivalentTo("Comentário excluido com sucesso");
        }


        [Test]
        [Category("Comentario")]
        public void DeveRetonarUmErroParaUmComentarioQueNãoExiste()
        {
            var requisitos = new RequisitosParaAlterarComentario
            {
                Id = Guid.NewGuid(),
                Texto = "lorem ipsum"
            };

            var repositorio = Substitute.For<IRepositorioComentario>();
            repositorio.BuscarPorId(requisitos.Id).ReturnsNull();

            var servico = new LidarComAlteracaoDeComentario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().BeEquivalentTo("Comentário não existe");
        }


        [Test]
        [Category("Comentario")]
        public void DeveRetornarUmaNotificacaoAoTentarExcluirUmComentarioQueNaoExiste()
        {
            var requisitos = new RequisitosParaExcluirComentario
            {
                Id = Guid.NewGuid()
            };

            var repositorio = Substitute.For<IRepositorioComentario>();

            repositorio.BuscarPorId(requisitos.Id).ReturnsNull();

            var servico = new LidarComExcluirComentario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().BeEquivalentTo("Comentário não existe");
        }

        [Test]
        [Category("Comentario")]
        public void DeveRetornarUmErroParaUmCadastroInvalidoDeComentario()
        {
            var requisitos = new RequisitosParaCriarComentario
            {
                UsuarioId = Guid.Empty,
                FotoId = Guid.Empty,
                Texto = ""
            };

            var repositorio = Substitute.For<IRepositorioComentario>();

            var servico = new LidarComCriacaoDeComentario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeFalse();
            resultado.Erros.Should().HaveCount(3);
        }
    }
}