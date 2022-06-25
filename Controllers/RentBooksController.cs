using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;
using System.Dynamic;

namespace OnlineLibrary.Controllers
{
    public class RentBooksController : Controller
    {
        private readonly IBooks _books;
        private readonly IUsers _users;
        private readonly IRentBooks _rentbooks;

        public RentBooksController(IBooks book, IRentBooks rentbook, IUsers user)
        {
            _books = book;
            _users = user; 
            _rentbooks = rentbook;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Role") == "Admin")
            {
                return View(_rentbooks.GetAllRentBooks());
            }
            else
            {
                return RedirectToAction("Index", " Home");
            }
        }
        [HttpGet]
        public IActionResult pinjambuku(string bookId)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Books = _books.GetBookDetails(bookId);
            RentBooks newrent = new RentBooks(bookId, HttpContext.Session.GetString("NIS"), mymodel.Books.Judul);
            mymodel.RentBooks = newrent;
            return View(mymodel);
        }
        [HttpPost]
        public IActionResult pinjambukuPost(string NIS, string bookId)
        {
            var judul = _books.GetBookDetails(bookId).Judul;
            RentBooks rent = new RentBooks(bookId, NIS, judul);
            _rentbooks.pinjam(rent, NIS, bookId);
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult kembalikanbuku(string rentid)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.RentBooks = _rentbooks.GetRentBookDetails(rentid);
            mymodel.Books = _books.GetBookDetails(mymodel.RentBooks.BooksId);

            return View(mymodel);
        }

        [HttpPost]
        public IActionResult kembalikanbukuPost(string rentid, string NIS)
        {
            _rentbooks.kembali(rentid);
            return RedirectToAction("Index", "Users", new { NIS = NIS});
        }
        [HttpGet]
        public IActionResult daftarPeminjaman(string userId)
        {
            var x = _rentbooks.GetUserRentBooks(userId);
            return View(x);
        }

    }
}
