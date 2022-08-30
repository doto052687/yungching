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
            /*
            List<Item> list = new List<Item>();
            list.Add(new Item("1111", "first item", 1, 100));
            list.Add(new Item("2222", "second item", 1, 200));
            */

            DBconnection dbconnection = new DBconnection();
            List<Item> list = dbconnection.getItems();
            ViewBag.List = list;

            return View();
        }

        public IActionResult Item(string _id)
        {
            string id = _id;
            DBconnection dbconnection = new DBconnection();

            Item item = dbconnection.getItem(id);

            return View(item);
        }
        
        [HttpPost]
        public IActionResult Item(Item item)
        {
            //System.Diagnostics.Debug.WriteLine("item.id= {0}", item.id);

            DBconnection dbconnection = new DBconnection();
            dbconnection.updateItem(item);
            return RedirectToAction("ItemList");
        }

        public IActionResult newItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult newItem(Item item)
        {
           // System.Diagnostics.Debug.WriteLine("item.id= {0}", item.id);

            DBconnection dbconnection = new DBconnection();
            if (dbconnection.isItemExist(item.id))
            {
                System.Diagnostics.Debug.WriteLine("物品id已存在,無法新增");
            }
            else
            {
                dbconnection.newItem(item);
            }
            return RedirectToAction("ItemList");
        }

        public IActionResult deleteItem(string _id)
        {
            string id = _id;
            DBconnection dbconnection = new DBconnection();
            if(dbconnection.isItemExist(id))
            {
                dbconnection.deleteItem(id);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("物品不存在");
            }
            return RedirectToAction("ItemList");
        }
    }
}