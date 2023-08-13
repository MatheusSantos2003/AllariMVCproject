using AllariMVCproject.Models;
using AllariMVCproject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AllariMVCproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IShoppingItemRepository itemRepository;



        public HomeController(ILogger<HomeController> logger, IShoppingItemRepository repository)
        {
            _logger = logger;
            this.itemRepository = repository;
        }

        public IActionResult Index()
        {
            TempData["fetched"] = false;
            ViewBag.items = itemRepository.GetAll();
            return View();
        }

        [HttpGet]
        public JsonResult ListItems()
        {
            itemRepository.Add(new ShoppingItem { Id = 4, Description = "This was added server-side!" });
            // Sleep function added to show the loading spinner
            Thread.Sleep(2000);
            return Json(itemRepository.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}