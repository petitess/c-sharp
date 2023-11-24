### Program.cs
```cs
Shape[] shapes =
{
    new Sphere(4),
    new Cube(5),
};

foreach (Shape shape in shapes)
{
    Console.Write("\n");
    shape.GetInfo();
    Console.WriteLine("Volume: " + shape.Volume()); ;
    Cube iceCube = shape as Cube;
    if ( iceCube == null )
    {
        Console.WriteLine("This shape is not cube");
    }
    if (shape is Cube)
    {
        Console.WriteLine("This shape is a cube");
    }
    object cube1 = new Cube(7);
    Cube cube2 = (Cube)cube1;
    Console.WriteLine("{0} has a volume if {1}", cube2.Name, cube2.Volume());
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
