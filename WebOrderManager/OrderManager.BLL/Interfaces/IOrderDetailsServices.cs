using OrderManager.BLL.DTO;

namespace OrderManager.BLL.Interfaces
{
    public interface IOrderDetailsServices
    {
        IEnumerable<OrderDetailDTO> GetOrderDetailsByOrderId(int orderId);
    }
}
