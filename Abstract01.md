### Program.cs
```cs
Shape[] shapes =
{
    new Sphere(4),
    new Cube(5),
};

foreach (Shape shape in shapes)
{
    shape.GetInfo();
    Console.WriteLine("Volume: " + shape.Volume()); ;
}
```
### Shape.cs
```cs
namespace exercise01
{
    abstract class Shape
    {
        public string Name { get; set; }
        public virtual void GetInfo() 
        {
            Console.WriteLine("This is a {0}" , Name);
        }
        public abstract double Volume();
    }
}
```
### Cube.cs
```cs
namespace exercise01
{
    internal class Cube : Shape
    {
        public double Lenght { get; set; }
        public Cube(double lenght) 
        {
            Name = "Cube";
            Lenght = lenght;
        }
        public override double Volume()
        {
            return Math.Pow(Lenght, 3);
        }
        public override void GetInfo()
        {
            Console.WriteLine("The cube has lenght of {0}", Lenght);
        }
    }
}
```
### Sphere.cs
```cs
namespace exercise01
{
    internal class Sphere : Shape
    {
        public double Radius {  get; set; }
        public Sphere(double radius) 
        {
            Name = "Sphere";
            Radius = radius;
        }
        public override double Volume()
        {
            return Math.PI * (Math.Pow(Radius, 3)) * 4 / 3;
        }
        public override void GetInfo()
        {
            Console.WriteLine("The radius of sphere is {0}", Radius);
        }
    }
}
```
