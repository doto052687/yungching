using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
