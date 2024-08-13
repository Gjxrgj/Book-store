using Book_store.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book_store.Repository
{
    public class BookStoreContext : IdentityDbContext<BookStoreUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookInOrder> BooksInOrder { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

    }
}
