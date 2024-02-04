using MazOrganization.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.ViewModels.Dashboard
{
    public class AddprojectmaininfoViewModel
    {
        public int ProjectId { get; set; }
        public int ReferralId { get; set; }
        public int PersonInfoId { get; set; }
        public int FieldInfoId { get; set; }
        public int UserId { get; set; }




        [Required(ErrorMessage = "لطفا نام پروژه را وارد کنید")]
        [Display(Name = "نام پروژه")]
        public string ProjectName { get; set; }

        [Display(Name = "نوع درخواست")]
        public string typeofapplication { get; set; }


        [Required(ErrorMessage = "لطفا نام و نام خانوادگی را وارد کنید")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا نام پدر را وارد کنید")]
        [Display(Name = "نام پدر")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "لطفا محل صدور را وارد کنید")]
        [Display(Name = "محل صدور")]
        public string PlaceIssue { get; set; }

        [Required(ErrorMessage = "لطفا شماره شناسنامه را وارد کنید")]
        [Display(Name = "شماره شناسنامه")]
        public string PersonNo { get; set; }

        [Required(ErrorMessage = "لطفا کدملی را وارد کنید")]
        [Display(Name = "کدملی")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "لطفا شماره همراه را وارد کنید")]
        [Display(Name = "شماره همراه")]
        public string Number { get; set; }

        [Required(ErrorMessage = "لطفا تلفن ثابت را وارد کنید")]
        [Display(Name = "تلفن ثابت")]
        public string TelNumber { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا آدرس را وارد کنید")]
        [Display(Name = "آدرس")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "لطفا مساحت زمین را وارد کنید")]
        [Display(Name = "مساحت زمین")]
        public string LandArea { get; set; }

        [Display(Name = "زیربنا")]
        public string Foundation { get; set; }

        [Display(Name = "نوع زمین")]
        public string LandType { get; set; }

        [Display(Name = "بخش ثبتی")]
        public string Registrationِepartment { get; set; }

        [Display(Name = "مفروز")]
        public string Assumed { get; set; }

        [Display(Name = "قطعه")]
        public string Piece { get; set; }

        [Display(Name = "اصلی")]
        public string Main { get; set; }

        [Display(Name = "فرعی")]
        public string Sub { get; set; }

        [Display(Name = "شماره قرارداد")]
        public string ContractNo { get; set; }

        [Display(Name = "واگذر کننده")]
        public string Assignor { get; set; }

        [Display(Name = "کدیکتا")]
        public string YektaCode { get; set; }

        public List<UploadViewModel> ProjectFiles { get; set; }

        public AddprojectmaininfoViewModel()
        {
            ProjectFiles = new List<UploadViewModel>();
        }
    }



    public class ProjectUserViewModel
    {
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
