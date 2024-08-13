using Book_store.Domain.Models;
using Book_store.Service.Implementation;
using Book_store.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_store.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService publisherService;
        private readonly IBookService bookService;
        public PublisherController(IPublisherService publisherService, IBookService bookService) 
        {
            this.publisherService = publisherService;
            this.bookService = bookService;
        }
        // GET: PublisherController
        public ActionResult Index()
        {
            return View(this.publisherService.GetAll());
        }
        
        // GET: PublisherController/Details/5
        public ActionResult Details(Guid id)
        {
            Publisher publisher  = this.publisherService.GetPublisher(id);
            return View(publisher);
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            ViewBag.Books = bookService.GetAllBooks();
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        public ActionResult Create([Bind("Id,Name,Description,PublisherImage")] Publisher publisher, Guid[] SelectedBookIds)
        {
            if (ModelState.IsValid)
            {
                publisher.Id = Guid.NewGuid();

                var selectedBooks = bookService.GetBooksByIds(SelectedBookIds);

                publisher.Books = selectedBooks;

                publisherService.Add(publisher);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Books = bookService.GetAllBooks();
            return View(publisher);
        }
        // GET: PublisherController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var publisher = this.publisherService.GetPublisher(id);
            if (publisher == null)
            {
                return NotFound();
            }
            ViewBag.Books = bookService.GetAllBooks();
            return View(publisher);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Description,PublisherImage")] Publisher publisher, Guid[] SelectedBookIds)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Books = bookService.GetAllBooks();
                return View(publisher);
            }
            List<Book> books = bookService.GetBooksByIds(SelectedBookIds);
            publisher.Books = books;
            publisherService.Update(publisher);

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublisherController/Delete/5
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
