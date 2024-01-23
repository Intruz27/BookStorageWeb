using BookStorageWeb.Models.Domain;

namespace BookStorageWeb.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllASync();
        Task<Book> GetAsync(Guid id);
        Task<Book> AddAsync(Book book);
        Task<Book> UdpateAsync(Book book);
        Task<bool> DeleteAsync(Guid id);
    }
}
