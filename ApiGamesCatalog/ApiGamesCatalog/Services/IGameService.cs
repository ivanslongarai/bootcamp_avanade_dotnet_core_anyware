using ApiGamesCatalog.InputModel;
using ApiGamesCatalog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Services
{
    public interface IGameService : IDisposable 
    {
        Task<List<GameViewModel>> Get(int page, int amount);
        Task<GameViewModel> Get(Guid id);
        Task<GameViewModel> InsertGame(GameInputModel game);
        Task UpdateGame(Guid id, GameInputModel game);
        Task UpdateGame(Guid id, decimal price);
        Task DeleteGame(Guid id);

    }
}
