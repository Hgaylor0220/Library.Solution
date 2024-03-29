using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _db;

        public BooksController(LibraryContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Book> model = _db.Books.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Book thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
            return View(thisBook);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            Book thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
            
            return View(thisBook);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}