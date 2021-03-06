﻿using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Werter.Dogs.Dominio.Requisitos.Usuario;
using Werter.Dogs.Dominio.Validacoes.Usuario;

namespace Werter.Dogs.Tests.Requisitos
{
    [TestFixture]
    public class RequisitosUsuarioTeste
    {
        private readonly ValidacaoParaCriarUsuario Validador = new ValidacaoParaCriarUsuario();

        [Test]
        public void EmailInvalido_RetornaFalso()
        {
            var requisitos = new RequisitosParaCriarUsuario
            {
                NomeDeUsuario = "werter",
                Email = "werter",
                Senha = "senha"
            };

            var result = Validador.Validate(requisitos);
            var erros = result.Errors;

            result.IsValid.Should().BeFalse();

            erros.Should().HaveCount(1);
            var erro = erros.FirstOrDefault();
            erro.PropertyName.Should().BeEquivalentTo("Email");
        }

        [Test]
        public void EmailInvalidoSenhaCom3Caracteres_Verdeiro()
        {
            var requisitos = new RequisitosParaCriarUsuario
            {
                NomeDeUsuario = "werter",
                Email = "werter@werter.com",
                Senha = "123"
            };
            var result = Validador.Validate(requisitos);
            var erros = result.Errors;

            result.IsValid.Should().BeFalse();

            erros.Should().HaveCount(1);
            var erro = erros.FirstOrDefault();
            erro.PropertyName.Should().BeEquivalentTo("Senha");
        }

        [Test]
        public void EmailValido_Verdeiro()
        {
            var requisitos = new RequisitosParaCriarUsuario
            {
                NomeDeUsuario = "werter",
                Email = "werter@werter.com",
                Senha = "senha"
            };

            var result = Validador.Validate(requisitos);
            var erros = result.Errors;

            result.IsValid.Should().BeTrue();

            erros.Should().HaveCount(0);
        }
    }
}