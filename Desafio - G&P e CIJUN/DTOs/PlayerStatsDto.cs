namespace Desafio___G_P_e_CIJUN.DTOs
{
	public class PlayerStatsDto
	{
		public string Player { get; set; } = string.Empty;
		public int TotalGames { get; set; }
		public double AverageScore { get; set; }
		public int MaxScore { get; set; }
		public int MinScore { get; set; }
		public DateTime FirstGame { get; set; }
		public DateTime LastGame { get; set; }
		public int RecordBreaks { get; set; }
		public string TimePlaying { get; set; } = string.Empty; // ✅ novo campo
	}

}
