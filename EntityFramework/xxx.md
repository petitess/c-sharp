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
```
