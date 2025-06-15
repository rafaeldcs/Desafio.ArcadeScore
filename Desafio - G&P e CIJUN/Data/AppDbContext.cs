using Desafio___G_P_e_CIJUN.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Desafio___G_P_e_CIJUN.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Score> Scores { get; set; }
	}
}
