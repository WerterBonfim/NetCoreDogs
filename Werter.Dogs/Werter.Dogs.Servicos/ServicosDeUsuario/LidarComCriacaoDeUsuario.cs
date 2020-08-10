using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos;

namespace Werter.Dogs.Servicos.ServicosDeUsuario
{
    public class LidarComCriacaoDeUsuario : ITarefa<RequisitosParaCriarUsuario>
    {
        private readonly IRepositorioCliente _clienteRepositorio;

        public LidarComCriacaoDeUsuario(IRepositorioCliente repositorioCliente)
        {
            _clienteRepositorio = repositorioCliente;
        }

        public IResultado LidarCom(RequisitosParaCriarUsuario requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(false, "Não foi possivel criar o usuário", requisitos.ListaErros()?.ToArray());

            if (NomeDeUsuarioJaFoiRegistrado(requisitos.NomeDeUsuario))
                return new ResultadoDaTarefa(false, "Nome de usuário já foi registrado");

            if (EmailJaFoiRegistrado(requisitos.Email))
                return new ResultadoDaTarefa(false, "Email já registrado");

            var senhaCriptografada = HashUtil.GetSha256FromString(requisitos.Senha);            
            var usuario = new Usuario(requisitos.NomeDeUsuario, requisitos.Email, senhaCriptografada);
            _clienteRepositorio.Inserir(usuario);
            _clienteRepositorio.Salvar();
            
            return new ResultadoDaTarefa(true, "Cadastrado com sucesso");
        }

        private bool EmailJaFoiRegistrado(string email)
        {
            return _clienteRepositorio.EmailExiste(email);
        }

        private bool NomeDeUsuarioJaFoiRegistrado(string nomeDeUsuario)
        {
            return _clienteRepositorio.NomeDeUsuarioExiste(nomeDeUsuario);
        }
    }
}
