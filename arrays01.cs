int[] numbers = new int[5];
numbers[0] = 4;
numbers[1] = 8;
numbers[2] = 15;
numbers[3] = 16;
numbers[4] = 23;

Console.WriteLine(numbers[1]);
Console.WriteLine(numbers.Length);
////////////////
int[] numbers = new int[] {4, 8, 15, 16, 23};
string[] names = new string[] { "Ann", "Bob" };

for (int i = 0; i < names.Length; i++) {

    Console.WriteLine(names[i] + ":" +numbers[i]);
}
////////////////
string[] names = new string[] { "Ann", "Bob" };

foreach (string name in names) {
     Console.WriteLine(name);
 }
//////////////
string[] names = new string[] { "Ann", "Bob" };

foreach (string name in names) {
     Console.WriteLine(name);
 }
////////////////////
string zig = "It's raining day";
char[] charArray = zig.ToCharArray();
Array.Reverse(charArray);

foreach (char c in charArray)
{
    Console.Write(c);
}
