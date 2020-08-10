namespace Werter.Dogs.WebApi.Seguranca
{
    public class ConfiguracaoDoToken
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Minutos { get; set; }
    }
}