using GameInventoryBackend.Data;
using GameInventoryBackend.Models;
using GameInventoryBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameInventoryBackend.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Game>> AddGame(Game newGame)
        {
            await _context.AddAsync(newGame);
            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<Game>
            {
                Data = newGame,
                Message = "New game added successfully.",
                Success = true
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Game>>> GetAllGames()
        {
            var dbGames = await _context.Games.ToListAsync();

            var serviceResponse = new ServiceResponse<List<Game>>
            {
                Data = dbGames,
                Message = "All available games.",
                Success = true
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<Game>> GetGameById(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == id);

            var serviceResponse = new ServiceResponse<Game>
            {
                Data = game,
                Success = true
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<Game>> RemoveGameById(int id)
        {
            var gameToRemove = await _context.Games.FirstAsync(g => g.ID == id);
            _context.Remove(gameToRemove);
            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<Game>
            {
                Data = gameToRemove,
                Message = "Game has been removed.",
                Success = true
            };

            return serviceResponse;
        }
    }
}
