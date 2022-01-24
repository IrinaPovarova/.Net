using OrderManager.DAL.Context;
using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;

namespace OrderManager.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private OrderManagerContext db;

        public OrderRepository(OrderManagerContext context)
        {
            this.db = context;
        }

        public OrderRepository()
        {
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(o => o.OrderID == id);

        }

        public Order Create(Order order)
        {
            return db.Orders.Add(order).Entity;
        }

        public void Update(Order order)
        {
            Order dbOrder = db.Orders.Find(order.OrderID);
            
            order.OrderDetails = null;
            if (order != null)
            {
                db.Orders.Update(order);
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public void Delete(Order item)
        {
            Order order = db.Orders.Find(item.OrderID);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
