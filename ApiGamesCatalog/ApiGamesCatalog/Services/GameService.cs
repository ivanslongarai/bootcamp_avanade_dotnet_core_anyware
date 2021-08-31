using ApiGamesCatalog.InputModel;
using ApiGamesCatalog.Repositories;
using ApiGamesCatalog.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ApiGamesCatalog.Entities;
using ApiGamesCatalog.Exceptions;

namespace ApiGamesCatalog.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameViewModel>> Get(int page, int amount)
        {
            var games = await _gameRepository.Get(page, amount);

            return games.Select(game => new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            })
                .ToList();

        }

        public async Task<GameViewModel> Get(Guid id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null)
                return null;

            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };

        }

        public async Task<GameViewModel> InsertGame(GameInputModel game)
        {
            var gameEntity = await _gameRepository.Get(game.Name, game.Producer);

            if (gameEntity.Count > 0)
                throw new AlreadyExistsGameException();

            var gameInsert = new Game
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };

            await _gameRepository.InsertGame(gameInsert);

            return new GameViewModel
            {
                Id = gameInsert.Id,
                Name = gameInsert.Name,
                Producer = gameInsert.Producer,
                Price = gameInsert.Price
            };
        }

        public async Task UpdateGame(Guid id, GameInputModel game)
        {
            var gameEntity = await _gameRepository.Get(id);

            if (gameEntity == null)
                throw new NotExistsGameException();

            gameEntity.Name = game.Name;
            gameEntity.Producer = game.Producer;
            gameEntity.Price = game.Price;

            await _gameRepository.UpdateGame(gameEntity);
        }

        public async Task UpdateGame(Guid id, decimal price)
        {
            var gameEntity = await _gameRepository.Get(id);

            if (gameEntity == null)
                throw new NotExistsGameException();

            gameEntity.Price = price;

            await _gameRepository.UpdateGame(gameEntity);
        }

        public async Task DeleteGame(Guid id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null)
            {
                throw new NotExistsGameException();
            }

            await _gameRepository.DeleteGame(id);
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }

    }
}
