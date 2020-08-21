using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Werter.Dogs.WebApi.Configuracoes.Seguranca
{
    public class ConfiguracaoDeAutenticacao
    {
        public ConfiguracaoDeAutenticacao()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            Credenciais = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

        public SecurityKey Key { get; }
        public SigningCredentials Credenciais { get; }
    }
}