namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "D:\\";

            var dir = new DirectoryInfo(path);
            var directories = dir.GetDirectories();

            foreach (var d in directories)
            {
                Console.WriteLine(d.CreationTime);
            }
        }
    }
}
