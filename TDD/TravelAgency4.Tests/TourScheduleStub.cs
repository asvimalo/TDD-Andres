using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency4.Tests
{
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours =
            new List<Tour>();
        public void CreateTour(string name, DateTime when, int seats)
        {
            Tours.Add(new Tour(name, when, seats));
        }

        public List<Tour> GetToursFor(DateTime when)
        {
            return Tours.Where(x => x.Date == when).ToList();
        }

        public bool NameExists(string name, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void OpenTour(DateTime today)
        {
            throw new NotImplementedException();
        }

        public bool OverlapExists(DateTime when)
        {
            throw new NotImplementedException();
        }

        public bool SeatsNegative(int seats)
        {
            throw new NotImplementedException();
        }

        public DateTime? SuggestedDayFor(DateTime when)
        {
            throw new NotImplementedException();
        }
    }
}
