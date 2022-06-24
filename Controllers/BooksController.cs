using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;
using MongoDB.Bson;

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
        public IActionResult Edit(string id)
        {
            var data = _context.GetBookDetails(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditBooks(string _id,Books book)
        {
            _context.update(_id, book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var data = _context.GetBookDetails(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(string _id)
        {
            var data = _context.GetBookDetails(_id);
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteBooks(string _id)
        {
            _context.delete(_id);
            return RedirectToAction("Index");
        }

    }
}
