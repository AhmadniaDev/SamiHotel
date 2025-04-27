using System.ComponentModel.DataAnnotations;

namespace WedMvcAdmin.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
