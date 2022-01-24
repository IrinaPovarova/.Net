using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Tests.Fake
{
    internal class FakeOrderDetailRepository : IRepository<OrderDetail>
    {
        private FakeContext _fakeContext;
        public FakeOrderDetailRepository(FakeContext context)
        {
            _fakeContext = context; 
        }

        public OrderDetail Create(OrderDetail item)
        {
            item.Product = new Product()
            {
                ProductID = item.ProductID,
                ProductName = "TestProductName"
            };
            _fakeContext.OrderDetails.Add(item);
            return item;
        }

        public void Delete(OrderDetail item)
        {
            var orderDetail = _fakeContext.OrderDetails.Find(od => od.OrderID == item.OrderID && od.ProductID == item.ProductID);
            if (orderDetail != null)
                _fakeContext.OrderDetails.Remove(orderDetail);
        }

        public IEnumerable<OrderDetail> Find(Func<OrderDetail, bool> predicate)
        {
            return _fakeContext.OrderDetails.Where(predicate).ToList();
        }

        public OrderDetail Get(int id)
        {
            return _fakeContext.OrderDetails.FirstOrDefault(o => o.OrderID == id);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _fakeContext.OrderDetails;
        }

        public void Update(OrderDetail item)
        {
            var orderDetail = _fakeContext.OrderDetails.Find(od => od.OrderID == item.OrderID && od.ProductID == item.ProductID);
            if (orderDetail != null)
            {
                orderDetail.Quantity = item.Quantity;   
                orderDetail.UnitPrice = item.UnitPrice; 
                orderDetail.Discount = item.Discount;
            }
        }
    }
}
