using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    public class UsersController: Controller
    {
        private readonly IUsers _context;

        public UsersController(IUsers context)
        {
            _context = context;
        }
        public IActionResult Index(string NIS)
        {  
            var user = _context.GetUserDetails(NIS);
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPost(string NIS, string password)
        {
            var user = _context.UserLogin(NIS, password);
            HttpContext.Session.SetString("NIS", NIS);
            HttpContext.Session.SetString("Nama", user.Nama);
            HttpContext.Session.SetString("Password", password);


            return RedirectToAction("Index", "Home", new {area = ""});
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPost(Users user)
        {
            _context.Register(user);
            return RedirectToAction("Login");
        }

        public IActionResult Update(string NIS)
        {
            var user = _context.GetUserDetails(NIS);
            return View();
        }

        public IActionResult UpdatePost(string NIS, Users user)
        {
            _context.update(NIS, user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync("Login");
                return RedirectToAction("Index", "Home");
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
