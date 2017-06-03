using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Exercise_Equality
{
    [TestFixture]
    public class UnitTests
    {
        private Order order1;
        private Order order2;
        private Order order3;

        [SetUp]
        public void Setup()
        {
            order1 = new Order() { OrderId = 1 };
            order1.AddOrderLine(new OrderLine() { Name = "Laptop HP", Price = 123m, Quantity = 101 });
            order1.AddOrderLine(new OrderLine() { Name = "Speaker", Price = 12m, Quantity = 101 });

            order2 = new Order() { OrderId = 1 }; ; //Order 2 is the same as order 1
            order2.AddOrderLine(new OrderLine() { Name = "Laptop HP", Price = 123m, Quantity = 101 });
            order2.AddOrderLine(new OrderLine() { Name = "Speaker", Price = 12m, Quantity = 101 });

            order3 = new Order() { OrderId = 2 }; //Different order
            order3.AddOrderLine(new OrderLine() { Name = "Apple Iphone", Price = 103m, Quantity = 101 });
            order3.AddOrderLine(new OrderLine() { Name = "Lamp", Price = 20m, Quantity = 100 });
        }

        [Test]
        public void TwoOrdersWithTheSameContentShouldEqual()
        {
            var equals = order1.Equals(order2);

            Assert.AreEqual(order1, order2);
        }

        [Test]
        public void TwoOrdersWithDifferentContentShouldNotEqual()
        {
            Assert.AreNotEqual(order1, order3);
            Assert.AreNotEqual(order2, order3);
        }

        [Test]
        public void TwoOrdersWithTheSameContentShouldCountAsOneInAHashSet()
        {
            var set = new HashSet<Order>();
            set.Add(order1);
            set.Add(order2);
            set.Add(order3);

            Assert.IsTrue(set.Count == 2);
        }

        [Test]
        public void RemovingOrdersShouldWork()
        {
            var orderList = new List<Order>();
            orderList.Add(order1);
            orderList.Add(order3);

            orderList.Remove(order2);   //Remove Order #2, as it is same as #1, then it should remove order 1

            Assert.IsTrue(orderList.Count == 1);
        }


        [Test]
        public void TwoIdenticalOrdersShouldHaveTheSameHashCode()
        {
            Assert.IsTrue(order1.GetHashCode() == order2.GetHashCode());
        }

        [Test]
        public void DupliateOrderLinesIsNotAllowed()
        {
            var order4 = new Order() { OrderId = 4 };
            order4.AddOrderLine(new OrderLine() { Name = "Laptop HP", Price = 123m, Quantity = 101 });
            order4.AddOrderLine(new OrderLine() { Name = "Laptop HP", Price = 123m, Quantity = 101 });
            order4.AddOrderLine(new OrderLine() { Name = "Laptop HP", Price = 123m, Quantity = 101 });

            Assert.IsTrue(order4.orderLines.Count == 1, "Error: Order4 should contain 1 item, contains " + order4.orderLines.Count);
        }


        [Test]
        public void AListOfOrdersShouldBesortable()
        {
            var orderList = new List<Order>();
            orderList.Add(order1);
            orderList.Add(order3);

            orderList.Sort();  //Should not crash!
        }

        [Test]
        public void AListOfOrdersShouldBesortableByOrderId()
        {
            var orderList = new List<Order>();
            orderList.Add(order3);
            orderList.Add(order1);

            orderList.Sort();  //We sort by OrderID!

            //Should be in the correct order
            Assert.IsTrue(orderList[0].OrderId==1);
            Assert.IsTrue(orderList[1].OrderId==2);
        }


        //---------------------------------------------------
        //Stretch tasks, Solve these if you have time

        [Test]
        public void UsingEqualsShouldWork()
        {
            var test = order1.CompareTo(order2);
            Assert.IsTrue(order1 == order2);
        }

        [Test]
        public void UsingNotEqualsShouldWork()
        {
            Assert.IsTrue(order1 != order3);
        }

        [Test]
        public void UsingNotEqualsShouldReturnFalseForDuplicateOrders()
        {
            Assert.IsFalse(order1 != order2);
        }

    }
}
