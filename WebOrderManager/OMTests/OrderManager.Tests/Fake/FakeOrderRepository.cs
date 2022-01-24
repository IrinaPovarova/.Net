using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Tests.Fake
{
    public class FakeOrderRepository : IRepository<Order>
    {
        private FakeContext _fakeContext;
        private int lastIndex;
        public FakeOrderRepository(FakeContext context)
        {
            _fakeContext = context;
            lastIndex = _fakeContext.Orders.Count + 1;
        }
        public IEnumerable<Order> GetAll()
        {
            var orders = _fakeContext.Orders;
            foreach (var order in orders)
            {
                order.OrderDetails = null;
            }
            return orders;
        }
      
        public Order Create(Order item)
        {
            item.OrderID = lastIndex;
            _fakeContext.Orders.Add(item);
            lastIndex++;
            var order = _fakeContext.Orders.Last();
            return order;
        }

        public void Delete(Order item)
        {
            var order = _fakeContext.Orders.FirstOrDefault(o => o.OrderID == item.OrderID);
            if (order != null)
            {
                _fakeContext.Orders.Remove(order);
            }
            else
            {
                Console.WriteLine($"OrderWithId  {item.OrderID} +  is not found");
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _fakeContext.Orders.Where(predicate);
        }

        public Order Get(int id)
        {
            return _fakeContext.Orders.FirstOrDefault(o => o.OrderID == id);
        }

        public void Update(Order item)
        {
            var id = item.OrderID;
            var order = _fakeContext.Orders.FirstOrDefault(o => o.OrderID == id);
            order.RequiredDate = item.RequiredDate;
            order.ShipName = item.ShipName;
            order.ShipAddress = item.ShipAddress;
            order.ShipCity = item.ShipCity;
            order.ShipCountry = item.ShipCountry;
            order.ShipPostalCode = item.ShipPostalCode;
            order.Freight = item.Freight;
            order.CustomerID = item.CustomerID;
        }
    }
}
