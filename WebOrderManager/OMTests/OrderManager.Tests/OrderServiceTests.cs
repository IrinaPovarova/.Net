using NUnit.Framework;
using OrderManager.BLL.DTO;
using OrderManager.BLL.Exceptions;
using OrderManager.BLL.Services;
using OrderManager.Tests.Fake;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private FakeUnitOfWork unitOfWork;
        private FakeContext fakeContext;

        [SetUp]
        public void TestInitialize()
        {
            fakeContext = new FakeContext();
            unitOfWork = new FakeUnitOfWork(fakeContext);
        }

        [Test]
        public void GetAllOrdersTest()
        {
            fakeContext = new FakeContext();
            unitOfWork = new FakeUnitOfWork(fakeContext);
            var service = new OrderService(unitOfWork);
            var orders = service.GetAllOrders();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());
            Assert.AreEqual(3, orders.Count());
        }

        [Test]
        public void GetOrderByIdTest()
        {
            var service = new OrderService(unitOfWork);
            var order = service.GetFullById(1);
            Assert.IsNotNull(order);
            Assert.IsTrue(order.Status == BLL.Enum.OrderStatuses.New);
            Assert.AreEqual(2, order.OrderDetails.Count);
            Assert.AreEqual("UK", order.ShipCountry);
        }

        [Test]
        public void CreateOrderTest()
        {
            var service = new OrderService(unitOfWork);
            var newOrder = new OrderDTO()
            {
                OrderID = 0,
                RequiredDate = DateTime.Now.AddMonths(9),
                ShipName = "Sherlock Holms",
                ShipAddress = "22, Baker Str",
                ShipCity = "Spb",
                ShipCountry = "RU",
                ShipPostalCode = "OX15 4NB",
                Freight = 1,
                CustomerID = "KING",
                EmployeeID = 4,
                ShipVia = 2,
                OrderDetails = new List<OrderDetailDTO>()
                {
                     new OrderDetailDTO()
                       {
                           ProductID = 2,
                           Quantity = 1,
                           Discount = 0.5f,
                           UnitPrice = 10,
                       }
                }
            };
            var order = service.Create(newOrder);
            var fullOrder = service.GetFullById(order.OrderID);
            Assert.IsNotNull(fullOrder);
            Assert.IsTrue(fullOrder.ShipCountry == "RU");
            Assert.IsTrue(fullOrder.ShipCity == "Spb");
            Assert.AreEqual(1, fullOrder.OrderDetails.Count);
            Assert.AreEqual(1, fullOrder.OrderDetails[0].Quantity);

        }
        [Test]
        public void UpdateOrderTest()
        {
            var service = new OrderService(unitOfWork);
            var order = service.GetFullById(1);
            order.ShipAddress = "11, Alexander Oy";
            order.ShipCity = "Koli";
            order.ShipCountry = "FI";
            order.ShipPostalCode = "FK15 021";
            order.Freight = 7;
            order.CustomerID = "NORTS";
            order.EmployeeID = 7;
            order.ShipVia = 3;
            order.OrderDetails[0].Quantity = 5;
            order.OrderDetails[0].UnitPrice = 5;
            order.OrderDetails[0].Discount = 0.55f;
            service.Update(order);
            var fullOrder = service.GetFullById(order.OrderID);
            Assert.IsNotNull(fullOrder);
            Assert.IsTrue(fullOrder.ShipCountry == "FI");
            Assert.IsTrue(fullOrder.ShipCity == "Koli");
            Assert.AreEqual(5, fullOrder.OrderDetails[0].UnitPrice);
            Assert.AreEqual(5, fullOrder.OrderDetails[0].Quantity);
        }

        [Test]
        public void DeleteOrderTest()
        {
            var service = new OrderService(unitOfWork);
            service.Delete(2);
            var order = service.GetFullById(2);
            Assert.IsTrue(order == null);
        }

        [Test]
        public void CanNotDeleteCompletedOrderTest()
        {
            var service = new OrderService(unitOfWork);
            Assert.Throws<CompletedStatusException>(() => { service.Delete(3); });
        }

        [Test]
        public void CanNotUpdateNotNewdOrderTest()
        {
            var service = new OrderService(unitOfWork);
            var order = service.GetFullById(3);
            Assert.Throws<NotNewStatusException>(() => { service.Update(order); });
        }
    }
}