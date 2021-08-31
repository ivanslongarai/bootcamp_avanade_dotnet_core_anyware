using ApiGamesCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Repositories
{
    public class GameRepository : IGameRepository
    {

        public static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            {Guid.Parse("4966263e-f8d6-4440-bfe0-6b29f4f58cc5"), new Game {Id = Guid.Parse("4966263e-f8d6-4440-bfe0-6b29f4f58cc5"), Name = "Red Dead Redemption 2", Producer = "Rock Star Games", Price = 280 } },
            {Guid.Parse("a6345fcc-3610-4aaf-aba3-9c2f25fdbb7f"), new Game {Id = Guid.Parse("a6345fcc-3610-4aaf-aba3-9c2f25fdbb7f"), Name = "Fifa 21", Producer = "EA", Price = 180 } },
            {Guid.Parse("e7065d18-ed0c-43f3-84fa-a4bd6a713d56"), new Game {Id = Guid.Parse("e7065d18-ed0c-43f3-84fa-a4bd6a713d56"), Name = "Fifa 20", Producer = "EA", Price = 150 } },
            {Guid.Parse("5d2ca3e5-121f-4ac3-9c7c-70a4606ab39e"), new Game {Id = Guid.Parse("5d2ca3e5-121f-4ac3-9c7c-70a4606ab39e"), Name = "Fifa 19", Producer = "EA", Price = 114 } },
            {Guid.Parse("06c3e03d-98a4-478b-ac61-601e94c65006"), new Game {Id = Guid.Parse("06c3e03d-98a4-478b-ac61-601e94c65006"), Name = "Fifa 18", Producer = "EA", Price = 100 } },
            {Guid.Parse("7ecef891-f84c-4548-abae-7393b9e97051"), new Game {Id = Guid.Parse("7ecef891-f84c-4548-abae-7393b9e97051"), Name = "The Wicher 3", Producer = "CD Project Red", Price = 270 } }
        };

        public Task DeleteGame(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose() 
        {
            // Since we are using a Dictionary memory data, we don't use this method now..
            // It was supposed to close bd connections
        }

        public Task<List<Game>> Get(int page, int amount)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * amount).Take(amount).ToList());
        }

        public Task<Game> Get(Guid id)
        {
            if (!games.ContainsKey(id))
                return null;

            return Task.FromResult(games[id]);
        }

        public Task<List<Game>> Get(string name, string producer)
        {
            return Task.FromResult(games.Values.Where(game => game.Name.Equals(name) && game.Producer.Equals(producer)).ToList());
        }

        public Task<List<Game>> GetWithoutLambda (string name, string producer)
        {
            var result = new List<Game>();

            foreach (var game in games.Values)
            {
                if ((game.Name.Equals(name)) && (game.Producer.Equals(producer)))
                {
                    result.Add(game);
                }
            }

            return Task.FromResult(result);
        }

        public Task InsertGame(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task UpdateGame(Game game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }
    }
}
