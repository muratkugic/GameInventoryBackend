using GameInventoryBackend.Models;
using GameInventoryBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameInventoryBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllGames()
        {
            return Ok(await _gameService.GetAllGames());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleGame(int id)
        {
            return Ok(await _gameService.GetGameById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(Game newGame)
        {
            await _gameService.AddGame(newGame);

            return StatusCode(201);
        }
    }
}
