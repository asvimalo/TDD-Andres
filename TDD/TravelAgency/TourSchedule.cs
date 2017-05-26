using System;
using System.Collections.Generic;

namespace TravelAgency
{
    public class TourSchedule
    {
        public Dictionary<DateTime, List<Tour>> SchecduledTours = new Dictionary<DateTime, List<Tour>>();

        public TourSchedule()
        {
        }
        public void OpenTour(DateTime today)
        {
            SchecduledTours.Add(today.Date, new List<Tour>());
        }
        public void CreateTour(string name, DateTime when, int seats)
        {
            var Tours = GetToursFor(when.Date);
            Tours.Add(new Tour(name, when.Date, seats));
        }

        public List<Tour> GetToursFor(DateTime when)
        {
            var x = SchecduledTours[when.Date];
            return x;
        }
    }
}