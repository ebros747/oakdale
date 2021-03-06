
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
            private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redit)
        {
            _database = redit.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketID)
        {
            return await _database.KeyDeleteAsync(basketID);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketID)
        {
            var data = await _database.StringGetAsync(basketID);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}