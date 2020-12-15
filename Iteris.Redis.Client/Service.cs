using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace Iteris.Redis.Client
{
    public class Service
    {
        private readonly string url = "https://localhost:44348/api/obter-dados";
        private OAuth oAuth;
        public Service(OAuth oAuth)
        {
            this.oAuth = oAuth;
        }

        public string ObterDados()
        {
          return url.WithOAuthBearerToken(oAuth.Token.token).GetStringAsync().Result;
        }
    }
}
