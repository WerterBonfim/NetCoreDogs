using System;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Comentario : EntidadeBase
    {
        public Comentario()
        {
        }

        public Comentario(Guid fotoId, Guid usuarioId, string texto)
        {
            FotoId = fotoId;
            UsuarioId = usuarioId;
            Texto = texto;
        }

        public Guid FotoId { get; set; }
        public Foto Foto { get; private set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Texto { get; private set; }

        public void AtualizarComentario(string texto)
        {
            Texto = texto;
            AtualizarDtHoraAlteracao();
        }
    }
}