using GameInventoryBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameInventoryBackend.Services.Interfaces
{
    public interface IGameService
    {
        Task<Game> GetGameById(int id);
        Task<List<Game>> GetAllGames();
        Task AddGame(Game newGame);
    }
}
