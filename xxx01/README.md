https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
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
### Constants
```cs
const double PI = 3.14;
const int weeks = 52, month = 12;
const string birthday = "01.01.2001";
```
### Mathod
```cs
GetText(TEST");
//(static) void is return type, mathod name(parameter)
static void GetText(string x)
{
    Console.WriteLine(x);
}
///
Add(4, 6); 
static int Add(int nr1, int nr2)
{
    Console.WriteLine(nr1 + nr2);
    return nr1 + nr2;
}
///
Devide(23, 9);
static double Devide(double nr1, double nr2)
{
    Console.WriteLine(nr1 / nr2);
    return nr1 / nr2;
}
```
### Try-catch
```cs
Console.WriteLine("Please enter a number");
string? input = Console.ReadLine();
Console.WriteLine("Please enter a second number");
string? input2 = Console.ReadLine();
try
{
    int inputAsInt = int.Parse(input);
    Console.WriteLine(double.Parse(input) / double.Parse(input2));
}
catch (FormatException)
{
    Console.WriteLine("format exeption, please enter the correct type.");
}
catch (OverflowException)
{
    Console.WriteLine("Overflow exception. The number was too long or too short.");
}
catch (Exception)
{
    Console.WriteLine("General exception");
}
finally
{
    Console.WriteLine("This is called anyways");
}
Console.ReadKey();
```
### Operator
```cs
int nr1 = 5;
int nr2 = 6;
//post increment operator
Console.WriteLine(nr1++);
//pre increment operator
Console.WriteLine(++nr1);
//decrement operator
Console.WriteLine(nr1--);
//pre decrement operator
Console.WriteLine(--nr1);
//additive operator
int result = nr1 + nr2;
int result2 = nr1 - nr2;
//multiplicative operator
int result3 = nr1 * nr2;
int result4 = nr1 / nr2;
//modulo operator - returns the remainder or signed remainder of a division
int result5 = 10 % 4;
//relational and type operators
bool isLower;
isLower = 3 < 7;
//equality operator
bool isEqual;
isEqual = 5 == 8;
//conditional operator
bool isEnabled = true;
bool isEmpty = true;
bool isEnabledAndEmpty = isEnabled &&  isEmpty;
bool isEnabledOrEmpty = isEnabled || isEmpty;
```
### TryParse Method 
```cs
string number = "100";
float parsedValue;
bool success = float.TryParse(number, out parsedValue);
if (success)
{
    Console.WriteLine("Parsing successful - number is " + parsedValue);
}
else
{
    Console.WriteLine("Parsing failed");
}
///
Console.WriteLine("What's the temperature?");
string? temp = Console.ReadLine();
int tempInt;
int tempX;

if (int.TryParse(temp, out tempInt))
{
    tempX = tempInt;
}
else
{
    tempX = 0;
}
if (tempInt < 5)
{
    Console.WriteLine("It's cold");
}
else if (tempInt > 5)
{
    Console.WriteLine("It's warm");
}
```
### Switch
```cs
int age = 15;
switch (age)
{
    case 15:
        Console.WriteLine("Too young to party");
        break;
    case 25: 
        Console.WriteLine("Good to go");
        break;
    case 45:
        Console.WriteLine("Too old to party");
        break;
    default: 
        Console.WriteLine("How old are you then");
        break;
}
```
### Ternary Operator
```cs
int number1 = 8;
int number2 = 5;
int number3 = 10;
string my = number3 > 100 ? "number3 is bigger than 100" : number1 > number2 ? "number1 is bigger" :  "number2 is bigger" ;
Console.WriteLine(my);
```
### Loops
```cs
for (int counter = 0; counter <= 12; counter+=3)
{
    Console.WriteLine(counter);
}
//
for (int number = 0;  number <= 20; number+=2)
{
    Console.WriteLine(number);
}
```
