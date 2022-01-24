using OrderManager.DAL.Context;
using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;

namespace OrderManager.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private OrderManagerContext db;
        private OrderRepository orderRepository;
        private OrderDetailsRepository orderDetailsRepository;

        public EFUnitOfWork(OrderManagerContext context)
        {
            db = context;
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<OrderDetail> OrderDetails
        {
            get
            {
                if (orderDetailsRepository == null)
                    orderDetailsRepository = new OrderDetailsRepository(db);
                return orderDetailsRepository;
            }
        }
       
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
