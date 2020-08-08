﻿using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos;
using Werter.Dogs.Servicos.ServicosDeUsuario;

namespace Werter.Dogs.Tests.Servicos
{
    [TestFixture]
    public class ServicosDoUsuarioTeste
    {
        

        [Test, Category("Criacao")]
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

        [Test, Category("Criacao")]
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

        [Test, Category("Atualização")]
        public void TresCaracteresDeveInformarNomeDeUsuarioEInvalido()
        {
            var requisitos = new RequisitosParaAtualizarUsuario
            {
                Id = Guid.NewGuid(),
                Nome = "as",
                Senha = "senha"
            };

            var repositorio = Substitute.For<IRepositorioCliente>();

            //repositorio.BuscarPorId(requisitos.Id).Returns(new Usuario("teste", "teste@teste.com", "senha"));
            var servico = new LidarComAtualizacaoDeUsuario(repositorio);

            var resultado = servico.LidarCom(requisitos);
            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().BeEquivalentTo("Não foi possivel atualizar os dados do usuario");
            resultado.Erros.Should().HaveCount(1);

            var erro = resultado.Erros.First();
            erro.Should().BeEquivalentTo("O nome deve conter pelo menos 3 caracteres");

        }

        [Test, Category("Atualização")]
        public void DeveAtualizarComSucesso()
        {
            var requisitos = new RequisitosParaAtualizarUsuario
            {
                Id = Guid.NewGuid(),
                Nome = "nome certo",
                Senha = "senha"
            };

            var repositorio = Substitute.For<IRepositorioCliente>();

            repositorio.BuscarPorId(requisitos.Id).Returns(new Usuario("teste", "teste@teste.com", "senha"));
            var servico = new LidarComAtualizacaoDeUsuario(repositorio);

            var resultado = servico.LidarCom(requisitos);
            resultado.Sucesso.Should().BeTrue();
            resultado.Mensagem.Should().BeEquivalentTo("Usuário atualizado com sucesso");
            resultado.Erros.Should().BeNull();
        }

        [Test, Category("Atualização")]
        public void IdNulloDeveRetornarUmErro()
        {
            var requisitos = new RequisitosParaAtualizarUsuario
            {                
                Nome = "nome certo",
                Senha = "senha"
            };

            var repositorio = Substitute.For<IRepositorioCliente>();

            
            var servico = new LidarComAtualizacaoDeUsuario(repositorio);

            var resultado = servico.LidarCom(requisitos);
            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().BeEquivalentTo("Não foi possivel atualizar os dados do usuario");            

            resultado.Erros.Should().HaveCount(1);

            var erro = resultado.Erros.First();
            erro.Should().BeEquivalentTo("Id inválido");            
        }
    }
}