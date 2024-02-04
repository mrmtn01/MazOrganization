using System;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class report
    {
        [Key]
        public int reportId { get; set; }

        public int projectId { get; set; }

        [Required(ErrorMessage = "لطفا عنوان فعالیت را وارد کنید")]
        [Display(Name = "عنوان فعالیت")]
        public string reportName { get; set; }

        [Display(Name = "کاربر")]
        public int userId { get; set; }

        [Display(Name = "تاریخ انجام فعالیت")]
        public string date { get; set; }


        public Project project { get; set; }

    }
}
