using OrderManager.BLL.DTO;

namespace OrderManager.BLL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetFullById(int id);
        OrderDTO Create(OrderDTO orderDTO);
        void Delete(int id);
        void Update(OrderDTO orderDTO);
        void MarkAsCompleted(int id);
        void HandOverOrder(int id);
    }
}
 