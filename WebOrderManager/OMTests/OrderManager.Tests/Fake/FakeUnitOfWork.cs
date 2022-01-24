using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;

namespace OrderManager.Tests.Fake
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private static FakeOrderRepository fakeOrderRepository;
        private static FakeOrderDetailRepository fakeOrderDetailRepository;
        private FakeContext fakeDb;
        public FakeUnitOfWork(FakeContext context)
        {
            fakeDb = context;
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (fakeOrderRepository == null)
                    fakeOrderRepository = new FakeOrderRepository(fakeDb);
                return fakeOrderRepository;
            }
        }

        public IRepository<OrderDetail> OrderDetails
        {
            get
            {
                if (fakeOrderDetailRepository == null)
                    fakeOrderDetailRepository = new FakeOrderDetailRepository(fakeDb);
                return fakeOrderDetailRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
        }

        public void Save()
        {
        }
    }
}
