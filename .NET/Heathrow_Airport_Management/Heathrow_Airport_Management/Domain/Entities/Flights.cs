using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Flights
    {
        public Guid FlightId { get; set; }
        public string FlightName { get; set; }
        public int Capacity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public Flights() { }

        public Flights(Guid flightId, string flightName, int capacity,
            DateTime departureTime, DateTime arrivalTime, string source, string destination)
        {
            FlightId = flightId;
            FlightName = flightName;
            Capacity = capacity;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Source = source;
            Destination = destination;
        }

        public void GetDetails()
        {
            Console.WriteLine($"Flight ID:        {FlightId}");
            Console.WriteLine($"Flight Name:      {FlightName}");
            Console.WriteLine($"Capacity:         {Capacity}");
            Console.WriteLine($"Departure Time:   {DepartureTime}");
            Console.WriteLine($"Arrival Time:     {ArrivalTime}");
            Console.WriteLine($"Source:           {Source}");
            Console.WriteLine($"Destination:      {Destination}");
        }
    }
}
