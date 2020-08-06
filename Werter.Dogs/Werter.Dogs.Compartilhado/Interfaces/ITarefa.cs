using System;
using System.Collections.Generic;
using System.Text;

namespace Werter.Dogs.Compartilhado.Interfaces
{
    public interface ITarefa<T> where T : IRequisitos
    {
        IResultado LidarCom(T requisitos);
    }
}
