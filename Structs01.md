Structs Only:
- Cannot support inheritance
- Are value types
- Are passed by value (like integers)
- Cannot have a null reference (unless Nullable is used)
- Do not have a memory overhead per new instance - unless 'boxed'
### Program.cs 
```cs
Game game1;
game1.name = "Pokemon Go";
game1.developer = "Niantic";
game1.rating = 3.5;
game1.releaseDate = "01.07.2017";
game1.Display();
```
### Game.cs 
```cs
namespace exercise01
{
    //Structs are similar to Classes. They only support defined constractor, not default. They don't support inhertance.
    //https://stackoverflow.com/questions/13049/whats-the-difference-between-struct-and-class-in-net
    struct Game
    {
        public string name;
        public string developer;
        public double rating;
        public string releaseDate;
        public void Display()
        {
            Console.WriteLine(name + " is developed by " + developer + " and was released " + releaseDate);
        }
    }
}
```
