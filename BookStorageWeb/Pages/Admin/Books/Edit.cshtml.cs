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
    public class EditModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        
        [BindProperty]
        public Book EditBookRequest { get; set; }
        
        public EditModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task OnGet(Guid id)
        {
            EditBookRequest = await _bookRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            await _bookRepository.UdpateAsync(EditBookRequest);
            try {
            
                ViewData["Notification"] = new Notification
            {
                Message = "Dane zosta³y poprawnie zapisane!",
                Type = NotificationType.Success
            };
            }
            catch (Exception ex) {
                
                ViewData["Notification"] = new Notification
                {
                    Message = "Coœ posz³o nie tak!",
                    Type = NotificationType.Error
                };
            }
            return RedirectToPage("/Admin/Books/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await _bookRepository.DeleteAsync(EditBookRequest.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = NotificationType.Success,
                    Message = "Rekord zosta³ poprawnie usuniêty!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Books/List");
            }
            
            return Page();
        }
    }
}
