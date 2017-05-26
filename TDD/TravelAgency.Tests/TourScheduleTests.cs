using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;


namespace TravelAgency.Tests
{
    [TestFixture]
    public class TourScheduleTests
    {
        public TourSchedule sut { get; set; }

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
            sut.OpenTour(new DateTime(2013, 1, 1, 9, 0, 0));
            sut.OpenTour(new DateTime(2013, 1, 2, 9, 0, 0));
            sut.OpenTour(new DateTime(2013, 1, 3, 9, 0, 0));
        }
        [Test]
        public void CanCreateNewTour()
        {
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1), 
                20);

            var bookings = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual(1, bookings.Count, "Have a single tour");
            Assert.AreEqual("New years day safari", bookings[0].Name);
            Assert.AreEqual(20, bookings[0].Seats);
        }
        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);
            var toursInThisDate = sut.GetToursFor(new DateTime(2013, 1, 1));
            
            Assert.AreEqual(new DateTime(2013, 1, 1), toursInThisDate[0].Date);
        }
        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour(
              "Desp",
              new DateTime(2013, 1, 3), 20);
            sut.CreateTour(
                "R",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1), 20);
            sut.CreateTour(
                "X",
                new DateTime(2013, 1, 2), 20);
            sut.CreateTour(
                "A",
                new DateTime(2013, 1, 1), 20);
            sut.CreateTour(
               "DiaDesp",
               new DateTime(2013, 1, 2), 20);

            //Uncomment to test exception a 4th Tour the same day:

            //sut.CreateTour(
            //    "zzz",
            //    new DateTime(2013, 1, 1), 20);

            var toursInThisDate = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual(3, toursInThisDate.Count);
        }
        [Test]
        public void CannotPlaceOverlappingBookings()
        {
            sut.CreateTour(
               "R",
               new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1), 20);
            sut.CreateTour(
                "X",
                new DateTime(2013, 1, 1), 20);

            Assert.Throws<TourAllocationException>(() => sut.CreateTour("Tina", new DateTime(2013, 1, 1), 20)); }
    }
}
