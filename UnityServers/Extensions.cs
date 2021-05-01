using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnityServers
{
    public static class Extensions
    {
        public static long ToUnixTimestamp(this DateTime d)
        {
            var epoch = d - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)epoch.TotalSeconds;
        }
    }
}
