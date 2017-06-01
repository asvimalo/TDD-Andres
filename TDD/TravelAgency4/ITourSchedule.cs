using System;
using System.Collections.Generic;

namespace TravelAgency4
{
    public interface ITourSchedule
    {
        void OpenTour(DateTime today);
        void CreateTour(string name, DateTime when, int seats);
        List<Tour> GetToursFor(DateTime when);
        bool OverlapExists(DateTime when);
        bool NameExists(string name, DateTime date);
        bool SeatsNegative(int seats);
        DateTime? SuggestedDayFor(DateTime when);
        
    }
}