using Microsoft.EntityFrameworkCore;
using OrderManager.DAL.Context;
using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;

namespace OrderManager.DAL.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetail>
    {
        private OrderManagerContext db;

        public OrderDetailsRepository(OrderManagerContext context)
        {
            this.db = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return db.OrderDetails;
        }

        public OrderDetail Get(int id)
        {
            return db.OrderDetails.FirstOrDefault(o => o.OrderID == id);
        }

        public OrderDetail Create(OrderDetail orderDetail)
        {
            return db.OrderDetails.Add(orderDetail).Entity;
        }

        public IEnumerable<OrderDetail> Find(Func<OrderDetail, bool> predicate)
        {
            return db.OrderDetails.Include(o => o.Product).Where(predicate).ToList();
        }

        public void Update(OrderDetail item)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(item.OrderID, item.ProductID);
            if (orderDetail != null)
            {
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Quantity = item.Quantity;
                orderDetail.Discount = item.Discount;
            }
        }

        public void Delete(OrderDetail item)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(item.OrderID, item.ProductID );
            if (orderDetail != null)
                db.OrderDetails.Remove(orderDetail);
        }
    }
}
