using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
