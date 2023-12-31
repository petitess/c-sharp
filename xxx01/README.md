https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/

### [Loops](Loops01.md)
### [Collections](Arrays01.md)

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
### Members And Finalizers/Destructors
```cs
namespace exercise
{
    internal class Member
    {
        //member - private filed
        private string _memberName;
        private string _jobTitle;
        private int _salary;
        //member - public filed
        public int age;
        //member - property - exposes JobTitle safely - properties start with a capital letter
        public string MemberName 
        { 
            get { return _memberName; }
            set { _jobTitle = value; } 
        }
        //publi member method - can be caled from other classes
        public void Introducing(bool isFriend)
        {
            if (isFriend)
            {
                SharingPrivateInfo();
            }else
            {
                Console.WriteLine("Hi, my name is " + _memberName);
            }
        }
        public void SharingPrivateInfo() 
        {
            Console.WriteLine("My salery is " + _salary);
        }   
        //member constractor
        public Member()
        {
            age = 30;
            _memberName = "Ann";
            _jobTitle = "Developer";
            _salary = 20000;
        }
        //member - finalizer - destructor
        ~Member()
        {
            //cleanup statements
            Console.WriteLine("Destruction of member object");
        }
    }
}
```
### Stack
```cs
//defining a new stack
Stack<int> stack = new Stack<int>();
//Add value to stack
stack.Push(22);
stack.Push(66);
stack.Push(73);
//remove an item
if (stack.Count > 0)
{
    int? popped = stack.Pop();
    Console.WriteLine("Popped item: " + popped);
}
//return the element at the top without removing it
Console.WriteLine("Top value: " + stack.Peek());
while (stack.Count > 0)
{
    stack.Pop();
}
if (stack.Count > 0)
    Console.WriteLine("Top value: " + stack.Peek());
else 
    Console.WriteLine("Stack empty");
//store int in a Stack
int[] numbers = new int[] { 5, 8, 3, 86, 23, 86, 12 };
Stack<int> nr = new Stack<int>();
foreach (int number in numbers)
{
    Console.Write(" {0} ", number);
    nr.Push(number);
}
//display numbers in reversed order
Console.WriteLine("");
while (nr.Count > 0)
{
    int pop = nr.Pop();
    Console.Write(" {0} ", pop);
}
```
### Queue
```cs
//defining a new queue
Queue<int> queue = new Queue<int>();
//Add value to queue
queue.Enqueue(22);
queue.Enqueue(66);
queue.Enqueue(73);
//remove an item
if (queue.Count > 0)
{
    int? popped = queue.Dequeue();
    Console.WriteLine("Popped item: " + popped);
}
//return the element at the top without removing it
Console.WriteLine("Top value: " + queue.Peek());
while (queue.Count > 0)
{
    queue.Dequeue();
}
if (queue.Count > 0)
    Console.WriteLine("Top value: " + queue.Peek());
else 
    Console.WriteLine("Queue empty");
//store int in a Queue
int[] numbers = new int[] { 5, 8, 3, 86, 23, 86, 12 };
Queue<int> nr = new Queue<int>();
foreach (int number in numbers)
{
    Console.Write(" {0} ", number);
    nr.Enqueue(number);
}
//display numbers in reversed order
Console.WriteLine("");
while (nr.Count > 0)
{
    int pop = nr.Dequeue();
    Console.Write(" {0} ", pop);
}
```
### Regular expressions
```cs
string pattern = @"\d";
Regex regex = new Regex(pattern);
string text = "Hi there, my number is 1234567";
MatchCollection match = regex.Matches(text);
Console.WriteLine("Found {0} objects", match.Count);
foreach (Match m in match)
{
    GroupCollection group = m.Groups;
    Console.WriteLine("{0} found at {1}", group[0].Value, group[0].Index);
}
```
