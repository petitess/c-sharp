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
//Dictionary
Dictionary<string, string> dictionary = new Dictionary<string, string>(){
  {"Cheese", "Dairy" },
  {"Potatos", "Vegetables"},
  {"Ice Cream", "Freezer"}
};
Console.WriteLine(dictionary["Potatos"]);
Console.WriteLine(dictionary["Ice Cream"]);
```

### dotnet
---
```
dotnet restore
dotnet run
dotnet nuget list source
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

https://learn.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates
