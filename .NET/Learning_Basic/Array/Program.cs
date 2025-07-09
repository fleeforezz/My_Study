namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[3] { 1, 2, 3 };

            Console.WriteLine($"Length = {intArr.Length}");

            foreach (int i in intArr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
