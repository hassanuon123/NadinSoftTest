using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EndPoint.ViewModels.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="نام و نام خانوادگی را وارد نمایید")]
        [Display(Name ="نام و نام خانوادگی")]
        [MaxLength(100,ErrorMessage ="نام و نام خانوادگی نمی تواند بیش از 100 کارکتر باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="ایمیل را وارد کنید")]
        [EmailAddress]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پسورد را وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار پسورد را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="پسورد و تکرار آن باید برابر باشند")]
        [Display(Name = "تکرار پسورد")]
        public string RePassword { get; set; }

    }
}
