using System.ComponentModel.DataAnnotations;

namespace asp_ht4.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage = "Email is not written")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not written")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wrong Password")]
        public string ConfirmPassword { get; set; }
    }
}
