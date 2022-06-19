using Microsoft.AspNetCore.Mvc;

namespace OnlineLibrary.Controllers
{
    public class UsersController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
