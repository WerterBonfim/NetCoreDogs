namespace Werter.Dogs.Dominio.Validacoes
{
    public sealed class DetalheErro
    {
        public DetalheErro(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; }
        public string Mensagem { get; }
    }
}