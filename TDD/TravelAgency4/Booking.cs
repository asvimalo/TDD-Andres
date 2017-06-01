using System;
using System.Collections.Generic;

namespace TravelAgency4
{
    public class Booking
    {
        public string TourName { get; set; }
        public DateTime Date { get; set; }
        public Passenger Passenger { get; set; }

        public Booking(string tourname, DateTime date, Passenger passenger)
        {
            TourName = tourname;
            Date = date;
            Passenger = passenger;
        }
    }
}