using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using domain.contracts;
using domain.entites;
using StackExchange.Redis;

namespace presistance
{
    public class Basketrepo(IConnectionMultiplexer connectionMultiplexer) : ibasketrepo
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
        public async Task<bool> Deletebasketasync(string id)
        =>await _database.KeyDeleteAsync(id);

        public async Task<customerbasket> getbasketasync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            if(basket.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<customerbasket>(basket);
        }

        public async Task<customerbasket> updatebasketasync(customerbasket basket, TimeSpan? timeSpan = null)
        {
            var serializedbasket = JsonSerializer.Serialize(basket);
            var created = await _database.StringSetAsync(basket.id, serializedbasket, timeSpan ?? TimeSpan.FromDays(30));
            return created ?  await getbasketasync(basket.id):null    ;
        }
    }
}
