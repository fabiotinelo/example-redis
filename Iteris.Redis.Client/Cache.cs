using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Redis.Client
{

    public class Cache<T>
    {
        private static string keyAuth = "MY_TOKEN";

        private readonly IRedisClient redisClient;
        private readonly IRedisTypedClient<T> oAuthTypedClient;

        public Cache(IRedisClientsManager redisClientsManager)
        {
            this.redisClient = redisClientsManager.GetClient();
            this.oAuthTypedClient = redisClient.As<T>();
        }

        public bool Save(T model)
        {
            if (Get() != null)
                oAuthTypedClient.DeleteById(keyAuth);

            oAuthTypedClient.Store(model);

            return true;
        }

        public T Get() => oAuthTypedClient.GetById(keyAuth);

        public bool Clear()
        {

            oAuthTypedClient.DeleteById(keyAuth);
            return true;
        }
    }
}
