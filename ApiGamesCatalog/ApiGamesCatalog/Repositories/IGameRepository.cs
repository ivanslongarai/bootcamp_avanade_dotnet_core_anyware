using ApiGamesCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Repositories
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> Get(int page, int amount);
        Task<Game> Get(Guid id);
        Task<List<Game>> Get(string name, string producer);
        Task InsertGame(Game game);
        Task UpdateGame(Game game);
        Task DeleteGame(Guid id);
    }
}
