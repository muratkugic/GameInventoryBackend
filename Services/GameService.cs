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

        public async Task AddGame(Game newGame)
        {
            await _context.AddAsync(newGame);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetAllGames()
        {
            var dbGames = await _context.Games.ToListAsync();
            return dbGames;
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.ID == id);
        }
    }
}
