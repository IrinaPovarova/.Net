using OrderManager.DAL.Entities;

namespace OrderManager.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<OrderDetail> OrderDetails { get; }
        void Save();
    }
}
