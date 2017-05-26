using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        public Dictionary<DateTime, List<Tour>> ScheduledTours =
            new Dictionary<DateTime, List<Tour>>();
        
        public void OpenTour(DateTime today)
        {
            ScheduledTours.Add(today.Date, new List<Tour>());
        }
        public void CreateTour(string name, DateTime when, int seats)
        {
            //var dayTours = GetToursFor(when.Date);
            //var bookedTours = dayTours.Count;

            if (!OverlapExists(when.Date))
            {
                ScheduledTours[when.Date].Add(new Tour(name, when.Date, seats));
            }
            else
                throw new TourAllocationException("Can t add more than 3");

            //if(GetToursFor(when.Date).Count < 3)
            //    ScheduledTours[when.Date].Add(new Tour(name, when.Date, seats));
            //else if (GetToursFor(when.Date).Count == 3)
            //    throw new TourAllocationException("Can t add more than 3");

            //ScheduledTours[when.Date].Add(new Tour(name, when.Date, seats));

        }

        public List<Tour> GetToursFor(DateTime when)
        {         
            return  ScheduledTours[when.Date];
        }
        public bool OverlapExists(DateTime when)
        {
            var dayTours = GetToursFor(when.Date);
            var bookedTours = dayTours.Count;
            if (bookedTours < 3 && bookedTours >= 0)
                return false;
            else
                return true;
        }
    }
}