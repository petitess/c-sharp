#### Retrive data 
```cs
//First you need an intance of context
var context = new FotballLeagueDbContext();
//Select all teams
var teams = context.Teams.ToList();
foreach (var team in teams)
Console.WriteLine("1: " + team.Name);
//Select first team
var teamF = await context.Teams.FirstAsync();
Console.WriteLine("2: " + teamF.Name);
//Select a team using condition
var teamX = await context.Teams.FirstAsync(x => x.Name == "Waterhouse F.C.");
Console.WriteLine("3: " + teamX.Name);
//Select a team using condition
var teamY = await context.Teams.SingleAsync(team => team.TeamId == 2);
Console.WriteLine("4: " + teamY.Name);
//Select based on Id
var teamBAsedOnId = await context.Teams.FindAsync(3);
if (teamBAsedOnId != null)
Console.WriteLine("5: " + teamBAsedOnId.Name);
//Select all records that meet a condition
var teamsFiltered = await context.Teams.Where(x => x.Name == "Tivoli Gardens F.C." || x.Name == "Garden").ToListAsync();
foreach (var team1 in teamsFiltered)
Console.WriteLine("6: " + team1.Name);
//Select using contains()
var teamsLike = await context.Teams.Where(x => x.Name.Contains("Water")).ToListAsync();
foreach (var teamL in teamsLike)
Console.WriteLine("7: " + teamL.Name);
//Select using Like()
string search = "F.C.";
var teamsEF = await context.Teams.Where(x => EF.Functions.Like(x.Name, $"%{search}%")).ToListAsync();
foreach (var teamEF in teamsEF)
Console.WriteLine("8: " + teamEF.Name);

```
#### LINQ
```cs
//LINQ Syntax - Get all
var teamsA = await (from team in context.Teams select team).ToListAsync();
foreach (var teamA in teamsA)
Console.WriteLine("9: " + teamA.Name);
//LINQ Syntax - filter
var teamsB = await (from team in context.Teams where team.Name == "Tivoli Gardens F.C." select team).ToListAsync();
foreach (var teamB in teamsB)
Console.WriteLine("10: " + teamB.Name);
//LINQ Syntax - search
string searchC = "F.C.";
var teamsC = await (from team in context.Teams where EF.Functions.Like(team.Name, $"%{searchC}%") select team).ToListAsync();
foreach (var teamC in teamsC)
Console.WriteLine("11: " + teamC.Name);
```
#### Aggregate methods
```cs
//Count
var numberofTeams = await context.Teams.CountAsync();
Console.WriteLine("12: " + numberofTeams);
//Count filtered
string filter = "F.C.";
var numberofTeamsF = await context.Teams.CountAsync(x => EF.Functions.Like(x.Name, $"%{filter}%"));
Console.WriteLine("13: " + numberofTeamsF);
//Max
var maxTeams = await context.Teams.MaxAsync(x => x.TeamId);
Console.WriteLine("14: " + maxTeams);
//Mix
var minTeams = await context.Teams.MinAsync(x => x.TeamId);
Console.WriteLine("15: " + minTeams);
//Average
var averageTeams = await context.Teams.AverageAsync(x => x.TeamId);
Console.WriteLine("16: " + averageTeams);
//Sum
var sumTeams = await context.Teams.SumAsync(x => x.TeamId);
Console.WriteLine("17: " + sumTeams);
```
#### Grouping and Aggregating
```cs
//Group by
var groupedTeams = context.Teams.GroupBy(x => new { x.CreatedDate.Date, x.Name });
foreach (var teamG in groupedTeams)
Console.WriteLine("18: " + teamG.Key);
//Group by + filter 
var groupedTeamsW = context.Teams
    .Where(x => x.Name.Contains("Water"))
    .GroupBy(x => new { x.CreatedDate.Date, x.Name });
foreach (var teamGF in groupedTeamsW)
{
    Console.WriteLine("19: " + teamGF.Key);
    Console.WriteLine("20: " + teamGF.Sum(x => x.TeamId));
    foreach (var t in teamGF)
    {
        Console.WriteLine("21: " + t.Name);
    }
}
//Order by
var orderedTeams = await context.Teams
    .OrderBy(x => x.Name)
    .ToListAsync();
foreach (var teamO in orderedTeams)
Console.WriteLine("22: " + teamO.Name);
//Getting record with maximum value
var orderedTeamsMax = await context.Teams
    .OrderByDescending(x => x.TeamId)
    .FirstOrDefaultAsync();
Console.WriteLine("23: " + orderedTeamsMax.Name);
//Getting record with maximum value
var maxBy = context.Teams.MaxBy(x => x.Name); //Not working
```
```cs
//Skip and Take
var recordCount = 3;
var page = 0;
var next = true;
while (next)
{
    var teamsSkip = await context.Teams.Skip(page * recordCount).Take(recordCount).ToListAsync();
    foreach (var teamO in teamsSkip)
    { Console.WriteLine("24: " + teamO.Name); }
    Console.WriteLine("Enter 'true' for the next set of records, 'false' to exit");
    next = Convert.ToBoolean(Console.ReadLine());
    if (!next) break;
    page += 1;
}
```
#### Projections
```cs
//Select - projection
var teamNames = await context.Teams.Select(x => new { x.Name, x.CreatedDate } ).ToListAsync();
foreach (var team in teamNames)
    Console.WriteLine("25: " + team.Name);
```
```cs
//Projections and Anonymous types
var teams = await context.Teams
    .Select(x => new TeamDetails 
    {
        TeamId = x.Id,
        TeamName = x.Name,
        CoachName = x.Coach.Name,
        TotalHomeGoals = x.HomeMatches.Sum(y => y.HomeTeamScore),
        TotalAwayGoals = x.AwayMatches.Sum(y => y.AwayTeamScore)
    })
    .ToListAsync();

foreach (var team in teams)
{
    Console.WriteLine(team.TeamName + " " + team.CoachName + " Home goals: " + team.TotalHomeGoals );
}

class TeamInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class TeamDetails
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string CoachName { get; set; }
    public int TotalHomeGoals { get; set; }
    public int TotalAwayGoals { get; set; }
}
```
#### No Tracking
```cs
//No Tracking - not saving in memory - can be added to DbContextOptionBuilder
//.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
var teamsTracking = context.Teams.AsNoTracking().ToList();
foreach (var team in teamsTracking)
    Console.WriteLine("26: " + team.Name);
//List Types
Console.WriteLine("Enter '1' for Team with Id '1' or '2' for teams that contains 'F.C.'");
var option = Convert.ToInt32(Console.ReadLine());
List<Team> teamsAsList = new List<Team>();
if (option == 1)
{
    teamsAsList = teamsAsList.Where(x => x.TeamId == 1).ToList();
}
else if (option == 2)
{
    teamsAsList = teamsAsList.Where(x => x.Name.Contains("F.C.")).ToList();
}
foreach (var team in teamsAsList)
    Console.WriteLine("27: " + team.Name);
//IQueryables
var teamsAsQuery = context.Teams.AsQueryable();
if (option == 1)
{
    teamsAsQuery = teamsAsQuery.Where(x => x.TeamId == 1);
}
else if (option == 2)
{
    teamsAsQuery = teamsAsQuery.Where(x => x.Name.Contains("F.C."));
}
teamsAsList = await teamsAsQuery.ToListAsync();
foreach (var team in teamsAsQuery)
    Console.WriteLine("28: " + team.Name);
```
#### Filtering 
```cs
var teams = await context.Teams
    .Include("Coach")
    .Include(x => x.HomeMatches.Where(x => x.HomeTeamScore > 0))
    .ToListAsync();

foreach (var team in teams)
{
    Console.WriteLine($"{team.Name} - {team.Coach.Name}");
    foreach (var match in team.HomeMatches)
    {
        Console.WriteLine($" {match.HomeTeamScore}");
    }
}
```
