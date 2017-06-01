using System;

namespace TravelAgency4
{
    public class Tour
    {
        public int Seats { get;  set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public Tour(string name, DateTime when, int seats)
        {
            this.Name = name;
            this.Date = when;
            this.Seats = seats;
        }
    }
}