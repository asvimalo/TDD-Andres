using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency4
{
    public class TourSchedule : ITourSchedule
    {
        public Dictionary<DateTime, List<Tour>> ScheduledTours =
            new Dictionary<DateTime, List<Tour>>();

        
        public TourSchedule()
        {
            
        }
        public void OpenTour(DateTime today)
        {
            ScheduledTours.Add(today.Date, new List<Tour>());
        }
        public void CreateTour(string name, DateTime when, int seats)
        {
            if (OverlapExists(when.Date))
                throw new TourAllocationException("Suggested date: " + SuggestedDayFor(when.Date).ToString());
            else if(NameExists(name, when))
                throw new TourAllocationException("Name already in use...");
            else if (SeatsNegative(seats))
                throw new TourAllocationException("Please enter number of seats...");
            else
                ScheduledTours[when.Date].Add(new Tour(name, when.Date, seats));    
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
        public bool NameExists(string name, DateTime date)
        {
            bool answer = false;
            var dayTours = GetToursFor(date.Date);
            foreach (var tour in dayTours)
            {
                if (tour.Name == name)
                {
                    return true;
                }
                else
                    return false;
            }
            return answer;
        }
        public bool SeatsNegative(int seats)
        {           
            if (seats <= 0)
                return true;
            else
                return false;
        }

        public DateTime? SuggestedDayFor(DateTime when)
        {
            var dayTours = GetToursFor(when.Date);
            var bookedTours = dayTours.Count;
            if ((bookedTours < 3  && bookedTours >= 0) /*|| bookedTours == null*/)
                return when.Date;
            else
            {
                var dayToursNext = GetToursFor(when.AddDays(1).Date);
                var bookedToursNext = dayToursNext.Count;
                if (bookedToursNext < 3 && bookedToursNext >= 0)
                {
                    return when.AddDays(1).Date;
                }
                return SuggestedDayFor(when.AddDays(1).Date);
            }
               
        }
    }
}