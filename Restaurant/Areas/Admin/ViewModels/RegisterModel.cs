using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class RegisterModel
    {
        
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not Match Confirm Password")]
        public string? ConfirmPassword { get; set; }


    }
}
