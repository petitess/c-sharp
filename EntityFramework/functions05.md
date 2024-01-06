```cs
//FromSqlRow()
Console.WriteLine("Enter Team Name: ");
var teamName = Console.ReadLine();
var teamNameParam = new SqliteParameter("teamName", teamName);
var teams = context.Teams.FromSqlRaw(@$"SELECT * FROM Teams WHERE name = @teamName", teamNameParam);
foreach (var team in teams)
{
    Console.WriteLine(team.Name);
}
//FromSql()
teams = context.Teams.FromSql(@$"SELECT * FROM Teams WHERE name = {teamName}");
foreach (var team in teams)
{
    Console.WriteLine(team.Name);
}
//FromSqlInterpolated
teams = context.Teams.FromSqlInterpolated(@$"SELECT * FROM Teams WHERE name = {teamName}");
foreach (var team in teams)
{
    Console.WriteLine(team.Name);
}
//Mixing with LINQ
var teamsList = context.Teams.FromSql(@$"SELECT * FROM Teams")
    .Where(x => x.Id == 1)
    .OrderBy(x => x.Id)
    .Include("League")
    .ToList();
foreach (var team in teamsList)
{
    Console.WriteLine(team.Name);
}
//Execusting Stored Procedures
var leagueId = 1;
var league = context.Leagues
    .FromSqlInterpolated($"EXEC dbo.StoredProcedureToGetLeagueName {leagueId}");
//Non-quering statement
var someNewTeamName = "NewTeamName";
var success = await context.Database.ExecuteSqlInterpolatedAsync($"UPDATE Teams SET Name = {someNewTeamName}");

var teamToDelete = 1;
var successDelete = await context.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.DeleteTeam {teamToDelete}");

//Query Scalar or Non-Entity Type
var leagueIdGet = await context.Database.SqlQuery<int>($"SELECT Id FROM Leagues").ToListAsync();
```
