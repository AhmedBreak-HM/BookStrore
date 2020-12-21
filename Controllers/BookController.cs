using BookStore.DTO;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookrepo;
        private readonly IRepository<Author> _authorRepo;

        public BookController( IRepository<Book> bookrepo,IRepository<Author> authorRepo)
        {
            this._bookrepo = bookrepo;
            this._authorRepo = authorRepo;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var book = _bookrepo.list();
            return View(book);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = _bookrepo.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var dto = new AuthorForBookDTO {

                authors = _authorRepo.list().ToList()
            };
            return View(dto);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorForBookDTO book)
        {
            try
            {
                var Author = _authorRepo.Find(book.AuthorId);
                var bookDTO = new Book()
                {
                    Id = book.Id,
                    title = book.title,
                    Discrption = book.Discrption,
                    author = Author
                };

                _bookrepo.Add(bookDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        { 
            var book = _bookrepo.Find(id);
            var idAuthor = book.author == null ? 0 : book.author.Id;
            var Dto = new AuthorForBookDTO()
            {
                Id= book.Id, title = book.title,
                Discrption = book.Discrption,
                AuthorId = book.author.Id,
                authors = _authorRepo.list().ToList(),
            };
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorForBookDTO book)
        {
            try
            {
                var Author = _authorRepo.Find(book.AuthorId);
                var bookDTO = new Book()
                {
                    Id = book.Id,
                    title = book.title,
                    Discrption = book.Discrption,
                    author = Author
                };

                _bookrepo.Update(id, bookDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = _bookrepo.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bookrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
