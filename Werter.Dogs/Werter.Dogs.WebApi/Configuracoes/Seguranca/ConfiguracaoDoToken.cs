namespace Werter.Dogs.WebApi.Configuracoes.Seguranca
{
    public class ConfiguracaoDoToken
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Minutos { get; set; }
    }
}