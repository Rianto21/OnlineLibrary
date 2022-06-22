using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController

        private readonly IBooks _context;

        public BooksController(IBooks context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.GetAllBooks());
        }

        // GET: BooksController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBooks(Books book)  
        {
            _context.create(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string judul)
        {
            var data = _context.GetBookDetails(judul);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditBooks(string id,Books book)
        {
            _context.update(id, book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string judul)
        {
            var data = _context.GetBookDetails(judul);
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string judul)
        {
            var data = _context.GetBookDetails(judul);
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteBooks(string judul)
        {
            _context.delete(judul);
            return RedirectToAction("Index");
        }

    }
}
