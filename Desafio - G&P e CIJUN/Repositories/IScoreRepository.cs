using Desafio___G_P_e_CIJUN.Models;

namespace Desafio___G_P_e_CIJUN.Repositories
{
	public interface IScoreRepository
	{
		Task AddAsync(Score score);
		Task<List<Score>> GetTopScoresAsync(int top);
		Task<List<Score>> GetByPlayerAsync(string player);
		Task<Score?> GetByIdAsync(int id);
	}
}
