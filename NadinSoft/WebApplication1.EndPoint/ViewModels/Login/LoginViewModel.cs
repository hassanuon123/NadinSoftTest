using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EndPoint.ViewModels.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "پسورد را وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }
    }
}
