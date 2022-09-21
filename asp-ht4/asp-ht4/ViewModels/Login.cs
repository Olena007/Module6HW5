using System.ComponentModel.DataAnnotations;

namespace asp_ht4.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Email is not written")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not written")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
