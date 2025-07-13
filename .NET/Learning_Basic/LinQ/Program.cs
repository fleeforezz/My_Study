namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataSource = GetIntNumbers();
            Print(dataSource);

            //var ns = from n in dataSource 
            //         where GreaterThanZero(n)
            //         select n;

            var ns = dataSource.Where(n => GreaterThanZero(n) && n % 2 == 1);
            
            Print(ns);
        }

        static bool GreaterThanZero(int n)
        {
            return n > 0;
        } 

        static IEnumerable<int> GetIntNumbers()
        {
            var ns = new int[] { 1, 2, 3, 4, 123, 542, 1433, 12345, 465234 };

            return ns;
        }

        static void Print(IEnumerable<int> values)
        {
            Console.WriteLine("----------------------");
            foreach (var value in values)
            {
                Console.WriteLine($"{value}");
            }
        }
    }
}
