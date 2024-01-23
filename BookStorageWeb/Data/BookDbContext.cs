using BookStorageWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStorageWeb.Data
{
    public class BookDbContext: DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options): base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
