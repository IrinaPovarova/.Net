using Microsoft.AspNetCore.Mvc;
using OrderManager.BLL.Interfaces;
using OrderManager.Web.Models;
using System.Diagnostics;

namespace OrderManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService; 
        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            //  var orderDetails = _orderService.GetAllOrderDetails();
            // var produts = _orderService.GetAllProducts();
            //var order = _orderService.GetFullById(11077);
            return View(orders);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}