using Desafio___G_P_e_CIJUN.DTOs;
using Desafio___G_P_e_CIJUN.Models;

namespace Desafio___G_P_e_CIJUN.Services
{
	public interface IScoreService
	{
		Task<Score> RegisterScoreAsync(Score score);
		Task<List<Score>> GetTopScoresAsync();
		Task<PlayerStatsDto?> GetPlayerStatsAsync(string player);
		Task<Score?> GetScoreByIdAsync(int id);
	}
}
