namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;

            if (x <= y)
            {
                Console.WriteLine("Hello World");
                int sum = x + y;
                Console.WriteLine(sum);
            }
        }
    }
}
