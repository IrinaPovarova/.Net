using OrderManager.BLL.DTO;

namespace OrderManager.BLL.Interfaces
{
    public interface IProduct_Services
    {
        IEnumerable<ProductDTO> GetAllProductsByOrderId(int orderId);
    }
}
