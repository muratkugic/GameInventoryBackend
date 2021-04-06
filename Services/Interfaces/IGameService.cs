using GameInventoryBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameInventoryBackend.Services.Interfaces
{
    public interface IGameService
    {
        Task<ServiceResponse<Game>> GetGameById(int id);
        Task<ServiceResponse<List<Game>>> GetAllGames();
        Task<ServiceResponse<Game>> AddGame(Game newGame);
        Task<ServiceResponse<Game>> RemoveGameById(int id);
    }
}
