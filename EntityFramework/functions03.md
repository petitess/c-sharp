```cs
//Insert record with FK
var match = new Match
{
    AwayTeamId = 1,
    HomeTeamId = 2,
    HomeTeamScore = 0,
    AwayTeamScore = 0,
    Date = new DateTime(2024, 02, 01),
    TicketPrice = 20
};
await context.AddAsync(match);
await context.SaveChangesAsync();
//Insert Parent/Child
var team = new Team
{
    Name = "Tigers",
    Coach = new Coach
    {
        Name = "Johnson"
    }
};
await context.AddAsync(team);
await context.SaveChangesAsync();
//Insert Parent with Children
var league = new League
{
    Name = "Dobra Liga",
    Teams = new List<Team>
    { 
        new Team
        {
            Name = "Juventus",
            Coach = new Coach
            {
                Name = "Juve Coach"
            }
        },
        new Team
        {
            Name = "AC Milan",
            Coach = new Coach
            {
                Name = "Milan Coach"
            }
        }
    }
};
await context.AddAsync(league);
await context.SaveChangesAsync();
```
