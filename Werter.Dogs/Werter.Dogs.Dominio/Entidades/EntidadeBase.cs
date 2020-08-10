using System;

namespace Werter.Dogs.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; private set; }
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            this.DataHoraAlteracao = DateTime.Now;
        }

        public DateTime DataHoraAlteracao { get; private set; }

        public void AtualizarDtHoraAlteracao()
        {
            this.DataHoraAlteracao = DateTime.Now;
        }
    }


}
