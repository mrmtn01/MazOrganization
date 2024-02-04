using System;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.ViewModels.Dashboard
{
    public class EditprojectmaininfoViewModel
    {
        public int ProjectId { get; set; }
        public int ReferralId { get; set; }

        [Required(ErrorMessage = "لطفا نام پروژه را وارد کنید")]
        [Display(Name = "نام پروژه")]
        public string ProjectName { get; set; }

        [Display(Name = "نوع درخواست")]
        public string typeofapplication { get; set; }

        [Required(ErrorMessage = "لطفا معرف پروژه را وارد کنید")]
        [Display(Name = "معرف پروژه")]
        public string ReferralName { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "وضعیت حذف")]
        public bool IsDelete { get; set; }
        
        [Display(Name = "وضعیت پروژه")]
        public bool IsDone { get; set; }
    }

}
