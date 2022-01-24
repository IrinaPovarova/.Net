using AutoMapper;
using OrderManager.BLL.DTO;
using OrderManager.BLL.Interfaces;
using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;

namespace OrderManager.BLL.Services
{
    public class OrderDetailsService : IOrderDetailsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<OrderDetailDTO> GetOrderDetailsByOrderId(int orderId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetail, OrderDetailDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<OrderDetail>, List<OrderDetailDTO>>(_unitOfWork.OrderDetails.GetAll());
        }
    }
}
