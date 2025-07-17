using Domain.Entities;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new flight instance
            var flight = new Flights(
                Guid.NewGuid(),
                "VN123",
                180,
                new DateTime(2025, 7, 25, 14, 30, 0),
                new DateTime(2025, 7, 25, 17, 45, 0),
                "Ho Chi Minh City",
                "Hanoi"
            );

            // Display its details
            flight.GetDetails();
        }
    }
}
