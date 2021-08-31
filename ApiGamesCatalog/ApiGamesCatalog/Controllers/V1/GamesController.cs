using ApiGamesCatalog.InputModel;
using ApiGamesCatalog.Services;
using ApiGamesCatalog.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApiGamesCatalog.Exceptions;

namespace ApiGamesCatalog.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <sumary>Get all games using pagination</sumary>
        /// <remarks>It's not possible get games list without pagination</remarks>
        /// <param name="page">Set the used page. Minimum value =1</param>
        /// <param name="amount">Amount of records by page. Minimum 1, Maximum 50</param>
        /// <response code="200">Show the games list</response>
        /// <response code="204">Just in case there are no games to show</response>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Get([FromQuery, Range(1, int.MaxValue)] int page = 1,
            [FromQuery, Range(1, 50)] int amount = 5)
        {

            // throw new Exception(); <<--- just for testing...

            var getGames = await _gameService.Get(page, amount);

            if (getGames.Count == 0)
                return NoContent();

            return Ok(getGames);
        }

        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<List<object>>> Get(Guid gameId)
        {
            var game = await _gameService.Get(gameId);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> InsertGame([FromBody] GameInputModel gameInputModel)
        {
            try
            {
                var game = await _gameService.InsertGame(gameInputModel);
                return Ok(game);
            }
            catch (AlreadyExistsGameException ex)
            {
                return UnprocessableEntity($"Já existe um jogo com este nome para esta produtora. Original msg: {ex.Message}");
            }
        }

        [HttpPut("{gameId:guid}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid gameId, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.UpdateGame(gameId, gameInputModel);
                return Ok();
            }
            catch (NotExistsGameException ex)
            {
                return NotFound($"Este jogo não existe cadastrado. Original msg: {ex.Message}");
            }
        }

        [HttpPatch("{gameId:guid}/price/{price:double}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid gameId, [FromRoute] decimal price)
        {
            try
            {
                await _gameService.UpdateGame(gameId, price);
                return Ok();
            }
            catch (NotExistsGameException ex)
            {
                return NotFound($"Este jogo não existe cadastrado. Original msg: {ex.Message}");
            }
        }

        [HttpDelete("{gameId:guid}")]
        public async Task<ActionResult> DeleteGame([FromRoute] Guid gameId)
        {
            {
                try
                {
                    await _gameService.DeleteGame(gameId);
                    return Ok();
                }
                catch (NotExistsGameException ex)
                {
                    return NotFound($"Este jogo não existe cadastrado. Original msg: {ex.Message}");
                }
            }
        }

    }
}
