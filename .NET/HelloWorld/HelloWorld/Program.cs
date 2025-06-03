namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            int sum = 0;

            if (x <= y)
            {
                Console.WriteLine("Hello World");
                sum = x + y;
                Console.WriteLine(sum);
            }

            string testString = "Hallo";

            Console.WriteLine(testString.ToUpper());

            foreach (var item in testString)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(testString.IndexOf('o'));

            // Full name
            string name = "John Doe";

            // Location of the letter D
            int charPos = name.IndexOf("D");

            if (name.Contains("o") && sum >= 12) {
                Console.WriteLine("Yay");
            }

            // Get last name
            string lastName = name.Substring(charPos);

            // Print the result
            Console.WriteLine(lastName);
        }
    }
}
