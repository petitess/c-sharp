### SCOPES
```
classes are "black boxes"
private method is a accessibility modifier.They are called by members inside the class
private means that a method can be called by any other method inside of the same class
public method is a accessibility modifier. They are called by somebody outside of the class
private helper methods add some functionality to public methods
public properties
```
### Parse
```cs
string a = "15";
string b = "22";
int c = int.Parse(a);
int d = int.Parse(b);
Console.WriteLine(c + d);
///
string stringForFloat = "0.85"; // datatype should be float
string stringForInt = "12345"; // datatype should be int
float nr1 = float.Parse(stringForFloat, CultureInfo.InvariantCulture) ;
int nr2 = int.Parse(stringForInt);
Console.WriteLine(nr1 + nr2);

```
### String manipulation

```cs
string name = "Anton";
int age = 31;
Console.WriteLine("Hello, my name in {0}, I am {1} years old", name, age);
Console.WriteLine($"Hello, my name in {name}, I am {age} years old");
Console.WriteLine(@"Hello, my name in {0},
I am {1} years old", name, age);
Console.WriteLine("Hello, my name in {0}, \nI am {1} years old", name, age);
///
Console.WriteLine(@"D:\MUZ\myfile.txt");
Console.WriteLine("D:\\MUZ\\myfile.txt");
///
string s1 = "This is a string with a \"quotation marks\"";
Console.WriteLine(s1);
```
### String methods
```cs
string text = "expendables";
Console.WriteLine(text.Substring(0,6));
Console.WriteLine((" " + text).Trim());
Console.WriteLine(text.IndexOf("x"));
Console.WriteLine(String.IsNullOrEmpty(text));
///
string firstNAme = "Anton";
string lastNAme = "Svensson";
string fullName = string.Concat(firstNAme, " ",lastNAme);
Console.WriteLine(fullName);
///
string title = "Total Recall";
Console.WriteLine(String.Format("I enjoyed {0}", title));
```
