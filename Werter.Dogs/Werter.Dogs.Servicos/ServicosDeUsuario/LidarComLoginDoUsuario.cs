using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualBasic.CompilerServices;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos;

namespace Werter.Dogs.Servicos.ServicosDeUsuario
{
    public class LidarComLoginDoUsuario : ITarefa<RequisitosParaLogin>
    {
        private readonly IRepositorioCliente _clienteRepositorio;

        public LidarComLoginDoUsuario(IRepositorioCliente repositorioCliente)
        {
            _clienteRepositorio = repositorioCliente;
        }

        public IResultado LidarCom(RequisitosParaLogin requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(
                    false,
                    "Não foi possível efetuar o login",
                    listaDeErros: requisitos.ListaErros().ToArray());
            
            var usuario = _clienteRepositorio
                .Buscar(PorUsuarioESenha(requisitos))
                .FirstOrDefault();

            if (usuario is null)
                return new ResultadoDaTarefa(false, "Usuário ou senha inválidos");

            return new ResultadoDaTarefa(
                true,
                "Usuário encontrado com sucesso",
                dados: usuario);
        }

        private static Expression<Func<Usuario, bool>> PorUsuarioESenha(RequisitosParaLogin requisitos)
        {
            var senhaCriptografada = HashUtil.GetSha256FromString(requisitos.Senha);
            return x =>
                (x.NomeDeUsuario == requisitos.Login || x.Email == requisitos.Login) &&
                x.Senha == senhaCriptografada;
        }
    }
}