using ServiceStack.Redis;
using System;

namespace Iteris.Redis.Client
{
    class Program
    {
        private static Cache<TokenResult> tokenResult;
        private static OAuth oAuth;
        static void Main(string[] args)
        {
            string connectionString = "CfWQusi0QNRsxAyHOkDhVB9xQfHwVMYo@redis-19042.c89.us-east-1-3.ec2.cloud.redislabs.com:19042";
            IRedisClientsManager redisClientsManager = new BasicRedisClientManager(connectionString);
            tokenResult = new Cache<TokenResult>(redisClientsManager);
            oAuth = new OAuth(tokenResult);
            Service service = new Service(oAuth);


            bool exit = false;
            while (!exit)
            {
                string read = Console.ReadLine();
                if (read.Equals("autenticar"))
                    oAuth.Authenticate();
                else if (read.Equals("obter"))
                    Console.WriteLine(service.ObterDados());
                else if (read.Equals("sair"))
                    exit = true;
            }
        }

        private static void ObterDados()
        {
           
            
        }

    }
}
