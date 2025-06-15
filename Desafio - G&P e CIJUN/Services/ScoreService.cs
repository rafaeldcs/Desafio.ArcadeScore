using Desafio___G_P_e_CIJUN.DTOs;
using Desafio___G_P_e_CIJUN.Models;
using Desafio___G_P_e_CIJUN.Repositories;

namespace Desafio___G_P_e_CIJUN.Services
{
	public class ScoreService : IScoreService
	{
		private readonly IScoreRepository _repo;

		public ScoreService(IScoreRepository repo)
		{
			_repo = repo;
		}

		public async Task<Score> RegisterScoreAsync(Score score)
		{
			await _repo.AddAsync(score);
			return score;
		}

		public Task<List<Score>> GetTopScoresAsync() => _repo.GetTopScoresAsync(10);

		public async Task<PlayerStatsDto?> GetPlayerStatsAsync(string player)
		{
			var scores = await _repo.GetByPlayerAsync(player);
			if (!scores.Any()) return null;


			var stats = new PlayerStatsDto
			{
				Player = player,
				TotalGames = scores.Count,
				AverageScore = scores.Average(s => s.Points),
				MaxScore = scores.Max(s => s.Points),
				MinScore = scores.Min(s => s.Points),
				FirstGame = scores.First().Date,
				LastGame = scores.Last().Date,
				RecordBreaks = scores.Skip(1).Count(s =>
					s.Points > scores.TakeWhile(p => p.Date < s.Date).Max(p => p.Points))				
			};
			var months = ((stats.LastGame.Year - stats.FirstGame.Year) * 12) + stats.LastGame.Month - stats.FirstGame.Month;

			stats.TimePlaying = months < 1 ? "menos de 1 mês" :
				  months == 1 ? "1 mês" :
				  months < 12 ? $"{months} meses" :
				  $"{Math.Floor(months / 12.0)} ano(s)";
			return stats;
		}

		public Task<Score?> GetScoreByIdAsync(int id) => _repo.GetByIdAsync(id);
	}
}
