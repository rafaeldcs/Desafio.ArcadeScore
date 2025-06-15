using Desafio___G_P_e_CIJUN.Data;
using Desafio___G_P_e_CIJUN.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio___G_P_e_CIJUN.Repositories
{
	public class ScoreRepository : IScoreRepository
	{
		private readonly AppDbContext _context;

		public ScoreRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Score score)
		{
			_context.Scores.Add(score);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Score>> GetTopScoresAsync(int top)
		{
			return await _context.Scores
				.OrderByDescending(s => s.Points)
				.Take(top)
				.ToListAsync();
		}

		public async Task<List<Score>> GetByPlayerAsync(string player)
		{
			return await _context.Scores
				.Where(s => s.Player.ToLower() == player.ToLower())
				.OrderBy(s => s.Date)
				.ToListAsync();
		}

		public async Task<Score?> GetByIdAsync(int id)
		{
			return await _context.Scores.FindAsync(id);
		}
	}
}
