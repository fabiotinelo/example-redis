using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Redis.Client
{
    public class TokenResult
    {
        public string Id { get => Common.Key; }
        public string token { get; set; }
    }
}
