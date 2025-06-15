using Desafio___G_P_e_CIJUN.Models;
using Desafio___G_P_e_CIJUN.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio___G_P_e_CIJUN.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ScoresController : ControllerBase
	{
		private readonly IScoreService _service;

		public ScoresController(IScoreService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterScore([FromBody] Score score)
		{
			var result = await _service.RegisterScoreAsync(score);
			return CreatedAtAction(nameof(GetScore), new { id = result.Id }, result);
		}

		[HttpGet("ranking")]
		public async Task<IActionResult> GetRanking()
		{
			var topScores = await _service.GetTopScoresAsync();
			return Ok(topScores);
		}

		[HttpGet("{player}")]
		public async Task<IActionResult> GetPlayerStats(string player)
		{
			var stats = await _service.GetPlayerStatsAsync(player);
			return stats == null ? NotFound() : Ok(stats);
		}

		[HttpGet("by-id/{id}")]
		public async Task<IActionResult> GetScore(int id)
		{
			var score = await _service.GetScoreByIdAsync(id);
			return score == null ? NotFound() : Ok(score);
		}
	}
}
