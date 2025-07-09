using System.Text;

namespace Learning_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = $"Hello World my name is nhat and today is {DateTime.Now}";
            String s2 = "Yay";

            Console.WriteLine(s1);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(s1);
            stringBuilder.Append(s2);

            string s = stringBuilder.ToString();

            Console.WriteLine(s);
        }
    }
}
    
