using Microsoft.Extensions.Configuration;
using Mjos.Clean.Domain.Entities;
using System.Text.Json;

namespace Mjos.Clean.Persistence.Contexts
{
    public class ApplicationDbContextSeed
    {
        //public static async Task SeedAsync(ApplicationDbContext contex, ILoggerFactory loggerFactory)
        public static async Task SeedAsync(ApplicationDbContext context, IConfiguration configuration)
        {
            try
            {
                var seedDataPath = configuration["SeedData"];
                // Seed Clubs
                if (!context.Clubs.Any())
                {
                    var clubsFilePath = Path.Combine(seedDataPath, "Clubs.json");
                    var clubsData = await File.ReadAllTextAsync(clubsFilePath);
                    var clubs = JsonSerializer.Deserialize<List<Club>>(clubsData);

                    if (clubs != null)
                    {
                        var existingClubNames = new HashSet<string>(context.Clubs.Select(c => c.Name));
                        var newClubs = clubs.Where(c => !existingClubNames.Contains(c.Name)).ToList();

                        if (newClubs.Any())
                        {
                            await context.Clubs.AddRangeAsync(newClubs);
                        }
                    }
                }

                // Seed Countries
                if (!context.Countries.Any())
                {
                    var countriesFilePath = Path.Combine(seedDataPath, "Countries.json");
                    var countriesData = File.ReadAllText(countriesFilePath);
                    var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);

                    if (countries != null)
                    {
                        var existingCountryNames = new HashSet<string>(context.Countries.Select(c => c.Name));
                        var newCountries = countries.Where(c => !existingCountryNames.Contains(c.Name)).ToList();

                        if (newCountries.Any())
                        {
                            await context.Countries.AddRangeAsync(newCountries);
                        }
                    }
                }

                // Seed Stadiums
                if (!context.Stadiums.Any())
                {
                    var stadiumsFilePath = Path.Combine(seedDataPath, "Stadiums.json");
                    var stadiumsData = File.ReadAllText(stadiumsFilePath);
                    var stadiums = JsonSerializer.Deserialize<List<Stadium>>(stadiumsData);

                    if (stadiums != null)
                    {
                        var existingStadiumNames = new HashSet<string>(context.Stadiums.Select(s => s.Name));
                        var newStadiums = stadiums.Where(s => !existingStadiumNames.Contains(s.Name)).ToList();

                        if (newStadiums.Any())
                        {
                            await context.Stadiums.AddRangeAsync(newStadiums);
                        }
                    }
                }

                // Seed Players
                if (!context.Players.Any())
                {
                    var playersFilePath = Path.Combine(seedDataPath, "Players.json");
                    var playersData = File.ReadAllText(playersFilePath);
                    var players = JsonSerializer.Deserialize<List<Player>>(playersData);

                    if (players != null)
                    {
                        var existingPlayerNames = new HashSet<string>(context.Players.Select(p => p.Name));
                        var newPlayers = players.Where(p => !existingPlayerNames.Contains(p.Name)).ToList();

                        if (newPlayers.Any())
                        {
                            await context.Players.AddRangeAsync(newPlayers);
                        }
                    }
                }

                // Seed TeamSquads
                if (!context.TeamSquads.Any())
                {
                    var teamSquadsFilePath = Path.Combine(seedDataPath, "TeamSquads.json");
                    var teamSquadsData = File.ReadAllText(teamSquadsFilePath);
                    var teamSquads = JsonSerializer.Deserialize<List<TeamSquad>>(teamSquadsData);

                    if (teamSquads != null)
                    {
                        var existingSquads = new HashSet<string>(context.TeamSquads
                            .Select(ts => $"{ts.PlayerId}-{ts.ClubId}-{ts.Year}"));

                        var newTeamSquads = teamSquads.Where(ts =>
                            !existingSquads.Contains($"{ts.PlayerId}-{ts.ClubId}-{ts.Year}")).ToList();

                        if (newTeamSquads.Any())
                        {
                            await context.TeamSquads.AddRangeAsync(newTeamSquads);
                        }
                    }
                }

                // Save all changes at once to minimize database transactions
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database seeding: {ex.Message}");
            }
        }

    }
}
