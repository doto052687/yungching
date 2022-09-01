using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(Member member)
        {
            MemberConnection memberConnection = new MemberConnection();
            memberConnection.register(member);
            return RedirectToAction("Index","Home");
        }
    }
}
