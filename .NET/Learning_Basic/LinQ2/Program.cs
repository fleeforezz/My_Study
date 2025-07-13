namespace LinQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudents();
            Print(students.OrderByDescending(s => s.YoB));
        }

        static void Print(IEnumerable<Student> StudentList)
        {
            foreach (var student in StudentList)
            {
                Print(student);
            }
        }

        static void Print(Student student)
        {
            Console.WriteLine($"Name {student.Name}, City {student.City}, Yob {student.YoB}");
        }

        static IEnumerable<Student> GetStudents()
        {
            return new Student[]
            {
                new Student()
                {
                    Name = "Jso",
                    City = "HCMC",
                    YoB = 2004
                },

                new Student()
                {
                    Name = "Nhat",
                    City = "HCMC",
                    YoB = 2000
                },

                new Student()
                {
                    Name = "Jimmy",
                    City = "HCMC",
                    YoB = 1900
                }
            };
        }
    }
}
