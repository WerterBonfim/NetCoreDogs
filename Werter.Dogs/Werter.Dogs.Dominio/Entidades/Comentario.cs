using System;

namespace Werter.Dogs.Dominio.Entidades
{
    public sealed class Comentario : EntidadeBase
    {
        public Foto Foto { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Texto { get; private set; }

        public Comentario(Foto foto, Usuario usuario, string texto)
        {
            this.Foto = foto;
            this.Usuario = usuario;
            this.Texto = texto;
        }
    }
}