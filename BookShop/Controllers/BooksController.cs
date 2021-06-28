using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> listBooks = new List<Book>();

        // GET: BooksController
        public ActionResult Index()
        {
            return View(listBooks);
        }

        //search  Book
        public ActionResult Search(string searchText)

        {
            searchText = searchText.ToLower();

            List<Book> searchResults = listBooks.FindAll(b =>
                   b.Title.ToLower().Contains(searchText) || b.Description.ToLower().Contains(searchText)
                   || b.Authors.ToLower().Contains(searchText));
            return View(searchResults);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            Book model = listBooks.FirstOrDefault(b => b.BookId == id);
            if (model is null)
            {
                return View(nameof(Index));
            }
            return View(model);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View(new Book());
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            try
            {
                DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

                if (ModelState.IsValid) {
                    model.BookId = now.ToUnixTimeSeconds();
                    listBooks.Add(model);
                return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            Book model = listBooks.FirstOrDefault(b => b.BookId == id);
               if(model is null)
            {
                return View(nameof(Index));
            }
            return View(model);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    listBooks.Remove(listBooks.FirstOrDefault(b => b.BookId == id));
                    listBooks.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            Book model = listBooks.FirstOrDefault(b => b.BookId == id);
            if (model is null)
            {
                return View(nameof(Index));
            }
            return View(model);

        }
         
        public ActionResult DeleteBook(int id)
        {
            try
            {
                listBooks.Remove(listBooks.FirstOrDefault(b => b.BookId == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book Model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
