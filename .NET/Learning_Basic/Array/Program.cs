namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[3] { 1, 2, 3 };

            Console.WriteLine($"Length = {intArr.Length}");

            for (int i = 0; i <= intArr.Length; i++)
            {
                Console.WriteLine( intArr[i] );
            }
        }
    }
}
