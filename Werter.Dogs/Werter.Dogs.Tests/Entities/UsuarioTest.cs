using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Tests.Entities
{
    [TestFixture]
    public class UsuarioTest
    {
        [Test]
        public void EmailInvalido_RetornaFalso()
        {
            var usuario = new Usuario("werter", "werter", "senha");
            var eValido = usuario.EValido();
            var erros = usuario.ListaErrors();

            eValido.Should().BeFalse();

            erros.Should().HaveCount(1);
            var erro = erros.FirstOrDefault();
            erro.Propriedade.Should().BeEquivalentTo("Email");
            erro.Mensagem.Should().BeEquivalentTo("Email inválido");

        }
    }
}
