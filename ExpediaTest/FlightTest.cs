using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
        private readonly DateTime dateThatFlightLeaves = new DateTime(2015, 3, 19);
        private readonly DateTime dateThatFlightReturns = new DateTime(2015, 3, 29);

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dateThatFlightLeaves, dateThatFlightReturns, 500);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 20), 250);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            var target = new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 29), 500);
            Assert.AreEqual((200 + 10 * 20), target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadEndDate()
        {
            new Flight(new DateTime(2015, 3, 20), new DateTime(2015, 3, 5), 500);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 29), -500);
        }

        [Test()]
        public void TestThatFlightHasCorrectMiles()
        {
            var target = new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 29), 750);
            Assert.AreEqual(750, target.Miles);
        }

        [Test()]
        public void TestFlightEqualsAnotherFlight()
        {
            var target = new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 29), 750);
            var otherTarget = new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 29), 750);
            Assert.IsTrue(target.Equals(otherTarget));
        }

        [Test()]
        public void TestFlightEqualsOnAnotherObject()
        {
            var target = new Flight(new DateTime(2015, 3, 19), new DateTime(2015, 3, 29), 750);
            int otherTarget = 7;
            Assert.False(target.Equals(otherTarget));

        }
	}
}
