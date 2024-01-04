```cs
using PeriodicTimer timer = new(TimeSpan.FromMilliseconds(1000));
var i = 0;
while (await timer.WaitForNextTickAsync() && i < 5 )
{
    Console.WriteLine($"Execution #{ i + 1} ran at: {DateTime.Now.ToString("hh:mm:ss fff")}");
    i++;
    await Task.Delay(3000);
}
```
```cs
using PeriodicTimer timer = new(TimeSpan.FromMilliseconds(1000));
var i = 0;
while (await timer.WaitForNextTickAsync() && i < 5 )
{
    Console.WriteLine($"Execution #{ i + 1} ran at: {DateTime.Now.ToString("hh:mm:ss fff")}");
    i++;
    timer.Period = TimeSpan.FromMilliseconds(i * 1000); 
}
```
