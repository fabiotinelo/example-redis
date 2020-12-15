using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace Iteris.Redis.Client
{
    public class OAuth
    {
        private readonly Cache<TokenResult> cache;
        private readonly string urlAuthentication = "https://localhost:44348/api/login";

        public OAuth(Cache<TokenResult> cache)
        {
            this.cache = cache;
        }

        private TokenResult token;
        public TokenResult Token
        {
            get => token;
            set => token = value;
        }


        public void Authenticate()
        {
            token = cache.Get();

            if (token == null)
            {
                token = urlAuthentication.PostJsonAsync(new UserModel { Password = "123", User = "teste" }).ReceiveJson<TokenResult>().Result;
                cache.Save(token);
            }

        }
    }
}
