using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MazOrganization.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string username { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید")]
        [Display(Name = "رمز عبور")]
        public string password { get; set; }

        [Display(Name = "مرا به خاطر بسپر")]
        public bool rememberMe { get; set; }
    }
}
