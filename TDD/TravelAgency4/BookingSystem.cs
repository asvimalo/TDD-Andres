using System;
using System.Collections.Generic;

namespace TravelAgency4
{
    public class BookingSystem
    {
        private ITourSchedule tourSchedule;
        List<Booking> Tours = 
            new List<Booking>();
        public BookingSystem(ITourSchedule tour)
        {
            this.tourSchedule = tour;
        }
        
        public void CreateBooking(string name, DateTime date, Passenger passenger, int numberSeats)
        {
            Booking booking = new Booking(name, date, passenger);
            
            var tours = tourSchedule.GetToursFor(date);

            foreach (var tour in tours)
            {
                if (tour.Name == booking.TourName && tour.Seats > 0 && tour.Seats >= numberSeats)
                {
                    var seats = tour.Seats;
                    tour.Seats = seats - 1;
                    Tours.Add(booking);
                    return;
                }
                else if(tour.Seats < numberSeats)
                {
                    throw new TourAllocationException($"This number of Seats requested exceed by {numberSeats - tour.Seats}");
                    
                }
                  

            }
            var specificNameTour = tours.FindAll(x => x.Name == name);
            //var specificSeatsTour = tours.FindAll(x => x.Seats <= numberSeats);
            if (specificNameTour == null)
                throw new TourAllocationException($"This {booking.TourName} doesn't fit you");
        }
        public List<Booking> GetBookingFor(Passenger passenger)
        {
           
            return Tours.FindAll(x => x.Passenger == passenger);
        }

    }
}