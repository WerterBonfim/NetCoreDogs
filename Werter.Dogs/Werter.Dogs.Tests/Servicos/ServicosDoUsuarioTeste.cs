using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos;
using Werter.Dogs.Servicos.ServicosDeUsuario;

namespace Werter.Dogs.Tests.Servicos
{
    [TestFixture]
    public class ServicosDoUsuarioTeste
    {
        

        [Test]
        public void DeveInformarQueOEmailJaEstaEmUso()
        {
            var repositorio = Substitute.For<IRepositorioCliente>();
            
            var requisitos = new RequisitosParaCriarUsuario
            {
                Email = "werter@werter.com",
                NomeDeUsuario = "werter",
                Senha = "senha"
            };

            repositorio.EmailExiste(requisitos.Email).Returns(true);
            repositorio.NomeDeUsuarioExiste(requisitos.NomeDeUsuario).Returns(false);

            var servico = new LidarComCriacaoDeUsuario(repositorio);
            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeFalse("O email informado já foi cadastrado");
            resultado.Mensagem.Should().BeEquivalentTo("Email já registrado");
            
        }

        [Test]
        public void DeveInformarQueONomeDeUsuarioJaEstaEmUso()
        {
            var repositorio = Substitute.For<IRepositorioCliente>();
            
            var requisitos = new RequisitosParaCriarUsuario
            {
                Email = "werter@werter.com",
                NomeDeUsuario = "werter",
                Senha = "senha"
            };

            repositorio.EmailExiste(requisitos.Email).Returns(false);
            repositorio.NomeDeUsuarioExiste(requisitos.NomeDeUsuario).Returns(true);

            

            var servico = new LidarComCriacaoDeUsuario(repositorio);

            var resultado = servico.LidarCom(requisitos);

            resultado.Sucesso.Should().BeFalse("O nome de usuário já esta em uso");
            resultado.Mensagem.Should().BeEquivalentTo("Nome de usuário já foi registrado");

        }
    }
}
