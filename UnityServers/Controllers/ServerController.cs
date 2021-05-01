using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using UnityServers.Models;

namespace UnityServers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly Cache _cache;
        private readonly ILogger<ServerController> _logger;

        public ServerController(Cache cache, ILogger<ServerController> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var now = DateTime.UtcNow.ToUnixTimestamp();
            var values = _cache.Servers.Values.Where(s => s.LastActive > now - 60);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Post([FromBody]UnityServer server)
        {
            if(server.Id == 0) {
                server.Id = new Random().Next(0, 1000000);
            }

            server.LastActive = DateTime.UtcNow.ToUnixTimestamp();

            if (_cache.Servers.ContainsKey(server.Id)) {
                _cache.Servers[server.Id] = server;
            } else {
                _cache.Servers.TryAdd(server.Id, server);
            }

            return Ok(server);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_cache.Servers.ContainsKey(id)) {
                _cache.Servers.TryRemove(id, out var _);
            }

            return Accepted();
        }
    }
}
