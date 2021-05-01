using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UnityServers.Models
{
    public class UnityServer
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }

        public List<string> Users { get; set; } = new List<string>();

        [JsonIgnore]
        public long LastActive { get; set; }
    }
}
