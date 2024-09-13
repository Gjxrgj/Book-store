using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Book_store.Service.Implementation;
using Book_store.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.Security.Claims;

namespace Book_store.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService bookService;
        private readonly IPublisherService publisherService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IAuthorService authorService;
        public BookController(IBookService _booService,
            IShoppingCartService shoppingCartService,
            IPublisherService _publisherService,
            IAuthorService _authorService)
        {
            this.publisherService = _publisherService;
            this.bookService = _booService;
            this._shoppingCartService = shoppingCartService;
            this.authorService = _authorService;
        }
        // GET: BookController
        public ActionResult Index()
        {
            return View(bookService.GetAllBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(bookService.GetBookById(id));
        }

        public IActionResult AddToCart(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.GetBookById(id);

            BookInShoppingCart ps = new BookInShoppingCart();

            if (book != null)
            {
                ps.BookId = book.Id;
            }

            return View(ps);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId != null)
            {
                _shoppingCartService.AddToShoppingConfirmed(model, userId);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.Publishers = publisherService.GetAll();
            ViewBag.Authors = authorService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Title,BookImage,Price,Rating,PublisherId")] Book book, Guid[] AuthorIds)
        {

            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                book.Authors.AddRange(authorService.GetAll(AuthorIds));
                bookService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Publishers = publisherService.GetAll();
            ViewBag.Authors = authorService.GetAll();

            return View(book);
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.Publishers = publisherService.GetAll();
            return View(book);
        }


        [HttpPost]
        public ActionResult Edit([Bind("Id,Title,BookImage,Price,Rating, PublisherId")] Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Publishers = publisherService.GetAll();
                return View(book);
            }

            bookService.Update(book);

            return RedirectToAction(nameof(Index));
        }


        // GET: BookController/Delete/5
        public ActionResult Delete(Guid id)
        {
            bookService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
