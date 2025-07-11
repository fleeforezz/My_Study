namespace Lamda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sum = (int a, int b) => a + b;

            Func<int, int, string> function = (int a, int b) => (a + b).ToString();

            Action<string> upper = (s) => Console.WriteLine(s.ToUpper());

            var t = object (int a, int b) => a > b ? 0 : "A";

            Console.WriteLine(t(1, 2));
            Console.WriteLine(t(2, 1));

            Console.WriteLine(sum(3, 5));
            Console.WriteLine(function(3, 7));
            upper("Hello");


            int A = 100;
            int B = 200;

            Call((a, b) => a + b, A, B);
            Call((a, b) => a * b, A, B);
        }

        static void Call(Func<int, int, int> f, int a, int b)
        {
            Console.WriteLine(f(a, b));
        }
    }
}
