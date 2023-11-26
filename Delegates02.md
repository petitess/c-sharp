### Program 
```cs
namespace exercise01
{
    public class Program
    {
        public delegate float OperationDelegate(float a, float b);

        static void Main(string[] args)
        {
            ApplyOperation(4, 5, Multiply);
            Console.WriteLine(ApplyOperation(4, 5, Multiply));

            static float ApplyOperation(float a, float b, OperationDelegate opr)
            {
                float result;

                result = opr(a, b);

                return result;
            }

            static float Add(float a, float b)
            {
                return a + b;
            }

            static float Substract(float a, float b)
            {
                return a - b;
            }

            static float Multiply(float a, float b)
            {
                return a * b;
            }

            static float Divide(float a, float b)
            {
                return a / b;
            }
        }
    } 
}
```
