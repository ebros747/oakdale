using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public Task CacheResponseAsync(string cacheKey, object reponse, TimeSpan timeToLive)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCacheResponseAsync(string cachekey)
        {
            throw new NotImplementedException();
        }
    }
}