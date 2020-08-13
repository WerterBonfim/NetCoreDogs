using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio.Core;

namespace Werter.Dogs.Dominio.Repositorio
{
    public interface IRepositorioCliente : IRepositorioBase<Usuario>
    {
        bool EmailExiste(string email);
        bool NomeDeUsuarioExiste(string nomeDeUsuario);
    }
}