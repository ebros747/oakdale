using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object reponse, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string cachekey);
    }
}