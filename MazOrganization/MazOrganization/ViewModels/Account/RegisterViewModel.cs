using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MazOrganization.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [Remote("IsUsernameUsed", "Account")]
        public string username { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsEmailUsed", "Account")]
        public string email { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور خود را وارد کنید")]
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        public string confirmPassword { get; set; }
    }
}
