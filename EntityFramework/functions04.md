//Eager Loading - Include(), AsSplitQuery(), ThenInclude()
var leagues = await context.Leagues
    .Include(x => x.Teams)
    .ThenInclude(x => x.Coach)
    .ToListAsync();
foreach (var league in leagues)
{
    Console.WriteLine(league.Name);
    foreach (var team in league.Teams)
    {
        Console.WriteLine("  " + team.Name + " - " + team.Coach.Name);
    }

}
//Explicit Loading
var leagueX = await context.FindAsync<League>(1);
if (!leagueX.Teams.Any())
{
    Console.WriteLine("Teams have not been loaded");
}
await context.Entry(leagueX)
    .Collection(x => x.Teams)
    .LoadAsync();
if (leagueX.Teams.Any())
{
    foreach (var team in leagueX.Teams)
    {
        Console.WriteLine(team.Name);
    }
}
