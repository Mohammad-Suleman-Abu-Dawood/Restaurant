using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class LoginModel
    {
       
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
