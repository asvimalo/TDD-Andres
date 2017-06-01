using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency4;

namespace TravelAgency4.Tests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourSchedule;
        private BookingSystem sut;

        [SetUp]
        public void Init()
        {
            tourSchedule = new TourScheduleStub();
            //tourSchedule.OpenTour(new DateTime(2013, 1, 1));
            sut = new BookingSystem(tourSchedule);
        }
        [Test]
        public void CanCreateBooking()
        {

            tourSchedule.CreateTour("Safari time", new DateTime(2013, 1, 1), 10);
            //var tours = tourSchedule.Tours;
            Passenger newPassenger = new Passenger("Andrés", "Martinez");
            sut.CreateBooking("Safari time", new DateTime(2013, 1, 1), newPassenger, 3);
            var passengers = sut.GetBookingFor(newPassenger);
            Assert.That(passengers.Count == 1);
        }
        [Test]
        public void TryToBookOnANonExistingTour()
        {

            //tourSchedule.CreateTour("Safari time", new DateTime(2013, 1, 1), 10);
            //var tours = tourSchedule.Tours;
            Passenger newPassenger = new Passenger("Andrés", "Martinez");
            //Assert.Throws<TourAllocationException>(() => sut.CreateBooking("Safari time", new DateTime(2013, 1, 1), newPassenger));
            sut.CreateBooking("Safari time", new DateTime(2013, 1, 1), newPassenger, 3);
            var passengers = sut.GetBookingFor(newPassenger);
            Assert.That(passengers.Count == 0);
        }
        [Test]
        public void TryToBookOnANonExistingTourWithException()
        {
            Passenger newPassenger = new Passenger("Andrés", "Martinez");

            var passengers = sut.GetBookingFor(newPassenger);
            if (passengers == null)
            {
                Assert.Throws<TourAllocationException>(() => sut.CreateBooking("Safari time", new DateTime(2013, 1, 1), newPassenger, 3));
            }
        }
        [Test]
        public void TryToBookMoreThanAvailableSeatsException()
        {
            tourSchedule.CreateTour("Safari time", new DateTime(2013, 1, 1), 10);
            Passenger newPassenger = new Passenger("Andrés", "Martinez");

            Assert.Throws<TourAllocationException>(() => sut.CreateBooking("Safari time", new DateTime(2013, 1, 1), newPassenger, 11));

        }


    }
}
