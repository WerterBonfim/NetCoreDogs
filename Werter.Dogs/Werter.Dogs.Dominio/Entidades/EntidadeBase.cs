﻿using System;

namespace Werter.Dogs.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; private set; }
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
    }


}
