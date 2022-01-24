using Microsoft.AspNetCore.Mvc;
using OrderManager.BLL.DTO;
using OrderManager.BLL.Interfaces;

namespace OrderManager.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);

        }

        public ActionResult Details(int id)
        {
            var order = _orderService.GetFullById(id);
            return View(order);
        }

        public ActionResult Create()
        {
            var newOrder = new OrderDTO()
            {
                OrderID = 0,
                RequiredDate = DateTime.Now.AddMonths(9),
                ShipName = "Sherlock Holms",
                ShipAddress = "22, Baker Str",
                ShipCity = "London",
                ShipCountry = "USA",
                ShipPostalCode = "KY1-4NB",
                Freight = 1,
                CustomerID = "KING",
                EmployeeID = 4,
                ShipVia = 2,
                OrderDetails = new List<OrderDetailDTO>()
                {
                     new OrderDetailDTO()
                       {
                           ProductID = 2,
                           Quantity = 11,
                           Discount = 0.5f,
                           UnitPrice = 120,
                        }
                }
            };
            _orderService.Create(newOrder);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var order = _orderService.GetFullById(id);

            order.RequiredDate = DateTime.Now.AddMonths(9);
            order.ShipName = "Mary Crawly";
            order.ShipAddress = "22, Downton Abbey";
            order.ShipCity = "York";
            order.ShipCountry = "UK";
            order.ShipPostalCode = "YO17";
            order.Freight = 1;
            order.CustomerID = "LORD";
            order.OrderDetails.RemoveAt(0);
            order.OrderDetails.Add(
                     new OrderDetailDTO()
                     {
                         OrderID = id,
                         ProductID = 12,
                         Quantity = 6,
                         Discount = 0.5f,
                         UnitPrice = 100,
                     }
                );
            _orderService.Update(order);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult HandOverOrder(int id)
        {
            _orderService.HandOverOrder(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult MarkAsCompleted(int id)
        {
            _orderService.MarkAsCompleted(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
