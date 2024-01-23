using BookStorageWeb.Data;
using BookStorageWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStorageWeb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _bookDbContext.Book.AddAsync(book);
            await _bookDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBook = await _bookDbContext.Book.FindAsync(id);

            if (existingBook != null)
            {
                _bookDbContext.Book.Remove(existingBook);
                await _bookDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Book>> GetAllASync()
        {
            return await _bookDbContext.Book.ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await _bookDbContext.Book.FindAsync(id);
        }

        public async Task<Book> UdpateAsync(Book book)
        {
            var existingBook = await _bookDbContext.Book.FindAsync(book.Id);

            if (existingBook != null)
            {
                existingBook.Id = book.Id;
                existingBook.Title= book.Title;
                existingBook.Author = book.Author;
                existingBook.Type = book.Type;
                existingBook.Description = book.Description;
                existingBook.SerialNumber = book.SerialNumber;
                existingBook.Location = book.Location;
            };

            await _bookDbContext.SaveChangesAsync();
            return existingBook;
        }
    }
}
