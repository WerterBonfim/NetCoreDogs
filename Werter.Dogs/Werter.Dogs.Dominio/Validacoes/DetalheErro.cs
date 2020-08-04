namespace Werter.Dogs.Dominio.Validacoes
{
    public sealed class DetalheErro
    {
        public string Propriedade { get; private set; }
        public string Mensagem { get; private set; }

        public DetalheErro(string propriedade, string mensagem)
        {
            this.Propriedade = propriedade;
            this.Mensagem = mensagem;
        }
    }
}
