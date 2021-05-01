using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityServers.Models;

namespace UnityServers
{
    public class Cache
    {
        public ConcurrentDictionary<int, UnityServer> Servers = new ConcurrentDictionary<int, UnityServer>();
    }
}
