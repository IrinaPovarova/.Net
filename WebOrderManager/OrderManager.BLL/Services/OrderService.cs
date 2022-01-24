using AutoMapper;
using OrderManager.BLL.DTO;
using OrderManager.BLL.Exceptions;
using OrderManager.BLL.Interfaces;
using OrderManager.DAL.Entities;
using OrderManager.DAL.Interfaces;

namespace OrderManager.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orders = _unitOfWork.Orders.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.OrderDetails,
                   opts => opts.MapFrom(src =>
                       src.OrderDetails.Select(ci => ci.Product).ToList())))
                .CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
        }

        public OrderDTO GetFullById(int id)
        {
            var order = _unitOfWork.Orders.Get(id);
            if (order == null)
                return null;
            var orderDetais = _unitOfWork.OrderDetails.Find(od =>od.OrderID == id);
            order.OrderDetails = orderDetais.ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()
                       .ForMember(dest => dest.OrderDetails,
                   opts => opts.MapFrom(src =>
                       src.OrderDetails.Select(od => new OrderDetailDTO()
                       {
                           OrderID = od.OrderID,
                           ProductID = od.ProductID,
                           Quantity = od.Quantity,
                           Discount = od.Discount,
                           UnitPrice = od.UnitPrice,
                           ProductName = od.Product != null ? od.Product.ProductName : string.Empty,
                       }).ToList()))).CreateMapper();
            var orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        public OrderDTO Create(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>().ForMember(dest => dest.OrderDetails,
                   opts => opts.Ignore())).CreateMapper();
            var dbOrder = mapper.Map<OrderDTO, Order>(orderDTO);
            var newOrder =_unitOfWork.Orders.Create(dbOrder);
            _unitOfWork.Save();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetailDTO, OrderDetail>()).CreateMapper();
            foreach (var item in orderDTO.OrderDetails)
            {
                item.OrderID = newOrder.OrderID;
                var newOrderDetail = mapper.Map<OrderDetailDTO, OrderDetail>(item);
                _unitOfWork.OrderDetails.Create(newOrderDetail);
           }
            
            orderDTO.OrderID = newOrder.OrderID;
            _unitOfWork.Save();
            return orderDTO; 
        }

        public void Update(OrderDTO orderDTO)
        {
            var order = _unitOfWork.Orders.Get(orderDTO.OrderID);

            if (orderDTO.Status != Enum.OrderStatuses.New)
               throw new NotNewStatusException();
            order.OrderID = orderDTO.OrderID;
            order.RequiredDate = orderDTO.RequiredDate;
            order.ShipName = orderDTO.ShipName;
            order.ShipAddress = orderDTO.ShipAddress;
            order.ShipCity = orderDTO.ShipCity;
            order.ShipCountry = orderDTO.ShipCountry;
            order.ShipPostalCode = orderDTO.ShipPostalCode;
            order.Freight = orderDTO.Freight;
            order.CustomerID = orderDTO.CustomerID;
            var details = _unitOfWork.OrderDetails.Find(o => o.OrderID == orderDTO.OrderID);
            foreach (var item in details)
            {
                if (!orderDTO.OrderDetails.Any(od => od.OrderID == item.OrderID && od.ProductID == item.ProductID))
                    _unitOfWork.OrderDetails.Delete(item);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetailDTO, OrderDetail>()).CreateMapper();
            foreach (var item in orderDTO.OrderDetails)
            {
                var newOrderDetail = mapper.Map<OrderDetailDTO, OrderDetail>(item);
                var dbOrderDetail = details.FirstOrDefault(od => od.OrderID == item.OrderID && od.ProductID == item.ProductID);

                if (dbOrderDetail == null)
                {
                    _unitOfWork.OrderDetails.Create(newOrderDetail);
                }
                else if (newOrderDetail.Quantity != dbOrderDetail.Quantity || newOrderDetail.UnitPrice != dbOrderDetail.UnitPrice || newOrderDetail.Discount != dbOrderDetail.Discount)
                {
                    _unitOfWork.OrderDetails.Update(newOrderDetail);
                }
            }
            _unitOfWork.Save();
        }
        
        public void Delete(int id)
        {
            var order = GetFullById(id);
            
            if (order.Status != Enum.OrderStatuses.Completed)
            {
                var dbOrder = _unitOfWork.Orders.Get(id);
                _unitOfWork.Orders.Delete(dbOrder);
                _unitOfWork.Save();
            }
            else
            {
                throw new CompletedStatusException();
            }
        }

        public void HandOverOrder(int id)
        {
            var order = _unitOfWork.Orders.Get(id);
            order.OrderDate = DateTime.Now;
            _unitOfWork.Save();
        }

        public void MarkAsCompleted(int id)
        {
            var order = _unitOfWork.Orders.Get(id);
            order.ShippedDate = DateTime.Now;
            _unitOfWork.Save();
        }
    }
}
