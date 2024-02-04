

using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class Accounting
    {
        [Key]
        public int accountingId { get; set; }

        public int projectId { get; set; }

        [Display(Name = "عنوان خدمات")]
        [Required(ErrorMessage = "لطفا عنوان خدمات را پر کنید")]
        public string tittleService { get; set; }

        [Display(Name = "کاربر")]
        public int userId { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا مبلغ را وارد کنید")]
        public string priceService { get; set; }


        public Project project { get; set; }
        
    }
}
