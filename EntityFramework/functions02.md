```cs
//Add new object to SQL table
var newCoach = new Coach()
{
    Name = "Jose Mourinho",
    CreatedDate = DateTime.Now,
};
await context.Coaches.AddAsync(newCoach);
await context.SaveChangesAsync();
//Add a list of objects to SQL table
var newCoach1 = new Coach()
{
    Name = "Theodore Whitmore",
    CreatedDate = DateTime.Now,
};
var newCoach2 = new Coach()
{
    Name = "Oscar Tabarez",
    CreatedDate = DateTime.Now,
};
//Version 1
List<Coach> coaches = new List<Coach>
{
    newCoach1,
    newCoach2
};
foreach (var coach in coaches)
{
    await context.Coaches.AddAsync(coach);
}
await context.SaveChangesAsync();
//Version 2
await context.AddRangeAsync(coaches);
await context.SaveChangesAsync();
//Update data
var coachUpdate = await context.Coaches.FindAsync(5);
coachUpdate.Name = "Jose Pekerman";
await context.SaveChangesAsync();
//Update data
var coachUpdate1 = await context.Coaches.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 1);
coachUpdate1.Name = "Lucien Favre";
context.Update(coachUpdate1);
await context.SaveChangesAsync();
//Delete
var coachDelete = await context.Coaches.FindAsync(5);
//context.Remove(coachDelete);
context.Entry(coachDelete).State = EntityState.Deleted;
await context.SaveChangesAsync();
//Execute delete
var coachesFilterDelete = await context.Coaches.Where(x => x.Name == "Theodore Whitmore").ExecuteDeleteAsync();
//Execute Update
var coachesFilterUpdate = await context.Coaches.Where(x => x.Name == "Jose Mourinho")
    .ExecuteUpdateAsync(x => x.SetProperty(y => y.Name, "Max Allegri"));
```
