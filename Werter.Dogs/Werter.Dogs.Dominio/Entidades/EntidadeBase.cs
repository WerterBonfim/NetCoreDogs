using System;

namespace Werter.Dogs.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            DataHoraAlteracao = DateTime.Now;
        }

        public Guid Id { get; }

        public DateTime DataHoraAlteracao { get; private set; }

        public void AtualizarDtHoraAlteracao()
        {
            DataHoraAlteracao = DateTime.Now;
        }
    }
}