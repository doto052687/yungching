using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ItemList()
        {
            List<Item> list = new List<Item>();
            list.Add(new Item("1111", "first item", 1, 100));
            list.Add(new Item("2222", "second item", 1, 200));
            ViewBag.List = list;

            return View();
        }

    }
}