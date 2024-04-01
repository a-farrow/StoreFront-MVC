
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.UI.MVC.Models
{
    [Keyless]
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Must be a valid email address!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Subject field is required.")]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "Message field is required.")]
        public string Message { get; set; } = null!;
    }
}
