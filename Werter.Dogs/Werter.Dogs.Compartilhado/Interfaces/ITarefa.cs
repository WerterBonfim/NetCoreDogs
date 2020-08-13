namespace Werter.Dogs.Compartilhado.Interfaces
{
    public interface ITarefa<T> where T : IRequisitos
    {
        IResultado LidarCom(T requisitos);
    }
}