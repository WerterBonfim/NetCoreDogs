using System;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.WebApi.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(Guid id, string nome, string nomeDeUsuario)
        {
            Id = id;
            Nome = nome;
            NomeDeUsuario = nomeDeUsuario;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeDeUsuario { get; set; }
    }


    public static class UsuarioViewModelMap
    {
        public static UsuarioViewModel ParaViewModel(this Usuario usuario)
        {
            return new UsuarioViewModel(usuario.Id, usuario.Nome, usuario.NomeDeUsuario);
        }
    }
}