
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Data;

public class DataContext : DbContext
{
	protected readonly IConfiguration Configuration;
	protected readonly ILogger Logger;

	public DbSet<Character> Characters { get; set; }

	public DataContext(
		IConfiguration configuration,
		ILogger<DataContext> logger)
	{
		this.Configuration = configuration;
		this.Logger = logger;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		// connect to mysql with connection string from app settings
		var connectionString = this.Configuration.GetConnectionString("MySqlConnection");

		if (connectionString is null)
		{
			var message = "MySQL connection string is missing.";
			this.Logger.LogError(message);
			throw new NullReferenceException(message);
		}

		options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Character>().HasData(
			new Character
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Benag",
				Health = 100,
				Strength = 10,
				Defence = 15,
				Intelligence = 30,
				Class = RpgClass.WhiteMage
			},
			new Character
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Amrier",
				Health = 150,
				Strength = 20,
				Defence = 20,
				Intelligence = 15,
				Class = RpgClass.Monk
			}
		);
	}
}
