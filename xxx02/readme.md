---
Controllers help handle different API-requests made to our API and sending back a result to the user or doing some kind of interactionwith our database.

Dapper or Entity framework are used to connect and interact with a database. Dapper requires understanding of SQL. Entity framework has buildin SQL-functions.

### Variables
---
Variable is stored data with a name(alias) and address

TYPES:
- numeric, int
- text, decimal
- list 
- lookup
OPERATORS:
- mathematical
- comparison
```cs
// 1 byte (8 bit) unsigned, where signed means it can be negative
byte myByte = 255;
byte mySecondByte = 0;
Console.WriteLine(myByte);
Console.WriteLine(mySecondByte);
// 1 byte (8 bit) signed, where signed means it can be negative
sbyte mySbyte = 127;
sbyte mySecondSbyte = -128;
Console.WriteLine(mySbyte);
Console.WriteLine(mySecondSbyte);
// 2 byte (16 bit) unsigned, where signed means it can be negative
ushort myUshort = 65535;
Console.WriteLine(myUshort);
// 2 byte (16 bit) signed, where signed means it can be negative
short myShort = -32768;
Console.WriteLine(myShort);
// 4 byte (32 bit) signed, where signed means it can be negative
int myInt = 2147483647;
int mySecondInt = -2147483648;
Console.WriteLine(myInt);
Console.WriteLine(mySecondInt);
// 8 byte (64 bit) signed, where signed means it can be negative
long myLong = -9223372036854775808;
Console.WriteLine(myLong);
// 4 byte (32 bit) floating point number
float myFloat = 0.751f;
float mySecondFloat = 0.75f;
Console.WriteLine(myFloat);
Console.WriteLine(mySecondFloat);
// 8 byte (64 bit) floating point number
double myDouble = 0.751;
double mySecondDouble = 0.75d;
Console.WriteLine(myDouble);
Console.WriteLine(mySecondDouble);
// 16 byte (128 bit) floating point number
decimal myDecimal = 0.751m;
decimal mySecondDecimal = 0.75m;
Console.WriteLine(myDecimal);
Console.WriteLine(mySecondDecimal);

string myString = "Hello World";
Console.WriteLine(myString);
string myStringWithSymbols = "!@#$@^$%%^&(&%^*__)+%^@##$!@%123589071340698ughedfaoig137";
Console.WriteLine(myStringWithSymbols);
char myString2 = 'H';
Console.WriteLine(myString2);

Console.WriteLine(myFloat - mySecondFloat);
Console.WriteLine(myDouble - mySecondDouble);
Console.WriteLine(myDecimal - mySecondDecimal);

bool myBool = true;
```

### Data Structures
---
```cs
//Array version 1
string[] names = new string[3];
names[0] = "Ann";   
names[1] = "Bob";
names[2] = "Carl";
Console.WriteLine(names[1]);
//Array version 2
string[] fruits = {"Apple", "Orange", "Banana", "Pineapple"};
Console.WriteLine(fruits[3]);
//List
List<string> vegetables = new List<string>() {"Potatos", "Cucumber", "Celery"};
vegetables.Add("Beet");
Console.WriteLine(vegetables[3]);
//IEnumerable
IEnumerable<string> vegetables2 = vegetables; 
Console.WriteLine(vegetables2.First());
//Two dimensional array
string[,] twoArrays = new string[,] {
    {"Key", "Wallet"}, //First array
    {"Bag", "Purse"} //Second array
};
Console.WriteLine(twoArrays[0,1]);
Console.WriteLine(twoArrays[1,0]);
//Dictionary version 1
Dictionary<string, string> dictionary = new Dictionary<string, string>(){
    {"Cheese", "Dairy" },
    {"Potatos", "Vegetables"},
    {"Ice Cream", "Freezer"}
};
Console.WriteLine(dictionary["Potatos"]);
Console.WriteLine(dictionary["Ice Cream"]);
//Dictionary version 2
Dictionary<string, string[]> dictionary2 = new Dictionary<string, string[]>(){
    {"Dairy", new string[]{"Cheese", "Milk"}}
};
Console.WriteLine(dictionary2["Dairy"][0]);
```
### Operators and Conditionals
```cs
//Arithmetic operators
int intx = 5;
Console.WriteLine(intx);
intx ++;
Console.WriteLine(intx);
intx += 9;
Console.WriteLine(intx);
int inty = 10;
Console.WriteLine(intx * inty);
Console.WriteLine((double)intx / inty);
Console.WriteLine(Math.Pow(5,2));
Console.WriteLine(Math.Sqrt(25));

int myFirstValue = 7;
int mySecondValue = 5;
Console.WriteLine(myFirstValue + mySecondValue);
Console.WriteLine(myFirstValue - mySecondValue);
Console.WriteLine(myFirstValue * mySecondValue);
Console.WriteLine(myFirstValue > mySecondValue);
//String
string car = "Volvo";
Console.WriteLine(car);
car += " and Polestar";
Console.WriteLine(car);
car += " are owned by \"Volvo Personvagnar\"";
Console.WriteLine(car);
string[] carArr = car.Split("by ");
Console.WriteLine(carArr[1]);
//Conditionals
Console.WriteLine(intx.Equals(inty));
Console.WriteLine(intx.Equals(inty + 5));
Console.WriteLine(intx >= inty);
//And Or
Console.WriteLine(50 > intx && inty > 5);

```
### Conditional Statements
```cs
//Int
int intx = 5;
int inty = 10;
if (intx > inty)
{
    intx += 10;
}
Console.WriteLine(intx);
//String
string cow = "cow";
string bigCow = "Cow";
if (cow == bigCow)
{
    Console.WriteLine("Equal");
}
else if (cow == bigCow.ToLower())
{
    Console.WriteLine("Equal without case sensitivity.");
}
else
{
    Console.WriteLine("Not Equal");
}
//Switch
switch (cow)
{
    case "cow":
        Console.WriteLine("Lowercase");
        break;
    case "Cow":
        Console.WriteLine("Capitalized");
        break;
    default:
        break;
}
```
### Loops
```cs
//For
DateTime start = DateTime.Now;
int[] intsToCompress = new int[] { 10, 15, 20, 25, 30, 12, 34 };
int totalValue = 0;
for (int i = 0; i < intsToCompress.Length; i++)
{
    totalValue += intsToCompress[i];
}
Console.WriteLine((DateTime.Now - start).TotalSeconds);
Console.WriteLine(totalValue);
//Foreach
start = DateTime.Now;
totalValue = 0;
foreach (int intToCompress in intsToCompress)
{
    totalValue += intToCompress;
}
Console.WriteLine((DateTime.Now - start).TotalSeconds);
Console.WriteLine(totalValue);
//While
start = DateTime.Now;
int index = 0;
totalValue = 0;
while (index < intsToCompress.Length)
{
    totalValue += intsToCompress[index];
    index++;
}
Console.WriteLine((DateTime.Now - start).TotalSeconds);
Console.WriteLine(totalValue);
//Do while
start = DateTime.Now;
index = 0;
totalValue = 0;
do
{
    totalValue += intsToCompress[index];
    index++;
}
while (index < intsToCompress.Length);
Console.WriteLine((DateTime.Now - start).TotalSeconds);
Console.WriteLine(totalValue);
//Sum
totalValue = 0;
totalValue = intsToCompress.Sum();
Console.WriteLine(totalValue);
//if
totalValue = 0;
foreach (int intToCompress in intsToCompress)
{
    if (intToCompress > 20)
    {
        totalValue += intToCompress;
    }
}
Console.WriteLine(totalValue);

//Print every even number
List<int> myNumberList = new List<int>(){
    2, 3, 5, 6, 7, 9, 10, 123, 324, 54
};
foreach (int number in myNumberList) {
    if(number%2 == 0) {
        Console.WriteLine(number);
    }
}
```
### dotnet
---
```
dotnet new webapi --name DotnetAPI
dotnet restore
dotnet run
dotnet watch run
dotnet nuget list source
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
//SQL pakages
dotnet add package Dapper
dotnet add package microsoft.data.sqlclient
dotnet add package microsoft.entityframework
dotnet add package microsoft.entityframeworkcore
```

https://learn.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/
