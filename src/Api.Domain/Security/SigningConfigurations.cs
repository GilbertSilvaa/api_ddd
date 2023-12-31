using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; } = null!;
        public SigningCredentials SigningCredentials { get; set; } = null!;

        public SigningConfigurations()
        {
            using var provider = new RSACryptoServiceProvider(2048);
            Key = new RsaSecurityKey(provider.ExportParameters(true));

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
