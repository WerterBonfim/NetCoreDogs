using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Werter.Dogs.WebApi.Seguranca
{
    public class ConfiguracaoDeAutenticacao
    {
        public SecurityKey Key { get; }
        public SigningCredentials Credenciais { get; }

        public ConfiguracaoDeAutenticacao()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            
            Credenciais = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
