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
string stringForFloat = "0.85"; // datatype should be float
string stringForInt = "12345"; // datatype should be int
float nr1 = float.Parse(stringForFloat, CultureInfo.InvariantCulture) ;
int nr2 = int.Parse(stringForInt);
Console.WriteLine(nr1 + nr2);

```
### String manipulation

```cs
System.IO.File.WriteAllText(docPath + "\\myTest.txt", text);
NAMESPACE:System.IO
Class: File
Method:WriteAllText()

```
