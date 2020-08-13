using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Werter.Dogs.Compartilhado
{
    public class HashUtil
    {
        public static string GetSha256FromString(string dados)
        {
            var mensagem = Encoding.ASCII.GetBytes(dados);
            var hashString = new SHA256Managed();

            var hashValue = hashString.ComputeHash(mensagem);
            var agg = hashValue.Aggregate("", (s, b) => s + $"{b:x2}");

            return agg;
        }
    }
}