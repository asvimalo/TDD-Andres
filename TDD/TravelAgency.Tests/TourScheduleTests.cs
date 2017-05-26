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
        }
    }
}
