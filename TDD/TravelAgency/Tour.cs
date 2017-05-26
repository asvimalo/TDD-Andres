using System;

namespace TravelAgency
{
    internal class Tour
    {
        private int Seats;
        private string Name;
        private DateTime Date;

        public Tour(string name, DateTime when, int seats)
        {
            this.Name = name;
            this.Date = when;
            this.Seats = seats;
        }
    }
}