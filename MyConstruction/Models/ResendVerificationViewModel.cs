using System.ComponentModel.DataAnnotations;

namespace MyConstruction.Models
{
    public class ResendVerificationViewModel
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please provide your password")]
        public string Password { get; set; }
    }
}
