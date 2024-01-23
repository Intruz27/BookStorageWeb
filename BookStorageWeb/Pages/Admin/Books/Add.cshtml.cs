using BookStorageWeb.Data.Enums;
using BookStorageWeb.Models.Domain;
using BookStorageWeb.Models.Domain.ViewModels;
using BookStorageWeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BookStorageWeb.Pages.Admin.Books
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        [BindProperty]
        public AddBook AddBookRequest { get; set; }

        public AddModel(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }
        public void OnGet()
        {

            
        }

        public async Task<IActionResult> OnPost() {
            var book = new Book()
            {

                Title = AddBookRequest.Title,
                Author = AddBookRequest.Author,
                Type = AddBookRequest.Type,
                Description = AddBookRequest.Description,
                SerialNumber = AddBookRequest.SerialNumber,
                Location = AddBookRequest.Location,

            };
            await _bookRepository.AddAsync(book);


            var notification = new Notification
            {
                Type = NotificationType.Success,
                Message = "Poprawnie zapisano dane!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Books/List");
        }
    }
}
