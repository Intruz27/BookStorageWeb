using BookStorageWeb.Models.Domain;
using BookStorageWeb.Models.Domain.ViewModels;
using BookStorageWeb.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;


namespace BookStorageWeb.Pages.Admin.Books
{
    public class ListModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public List<Book> Book { get; set; }

        public ListModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task OnGet()
        {
            var notificationJSON = (string)TempData["Notification"];

            if (notificationJSON != null) {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJSON);
            }

            Book = (await _bookRepository.GetAllASync())?.ToList();

        }
    }
}
