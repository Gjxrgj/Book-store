using Book_store.Domain.Models;
using Book_store.Service.Implementation;
using Book_store.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Book_store.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IBookService bookService;
        public AuthorController(IAuthorService _authorService, IBookService _bookService) 
        {
            authorService = _authorService;
            bookService = _bookService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(authorService.GetAll());
        }

        // GET: Admin/Details/5
        public ActionResult Details(Guid id)
        {
            var booksByAuthor = bookService.GetAllBooks()
                                   .Where(b => b.Authors.Any(a => a.Id == id))
                                   .ToList();
            ViewBag.Books = booksByAuthor;
            return View(this.authorService.GetById(id));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,Surname,Age,Origin")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();

                authorService.Add(author);

                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(this.authorService.GetById(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Surname,Age,Origin")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            this.authorService.UpdateById(author);

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(Guid id)
        {
            this.authorService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
