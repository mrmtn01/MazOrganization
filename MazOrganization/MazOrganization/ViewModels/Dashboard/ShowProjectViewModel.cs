using System.ComponentModel.DataAnnotations;
using System;

namespace MazOrganization.ViewModels.Dashboard
{
    public class ShowProjectViewModel
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
        public string CreateDate { get; set; }

        [Display(Name = "وضعیت حذف")]
        public bool IsDelete { get; set; }

        [Display(Name = "وضعیت پروژه")]
        public bool IsDone { get; set; }

        public int PersonInfoId { get; set; }

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


        public int FieldInfoId { get; set; }


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
        public int financialId { get; set; }

        [Required(ErrorMessage = "لطفا مبلغ کل را وارد کنید")]
        [Display(Name = "مبلغ کل")]
        public int TotalAmount { get; set; }

        [Required(ErrorMessage = "لطفا بدهکار را وارد کنید")]
        [Display(Name = "بدهکار")]
        public int Debtor { get; set; }

        [Required(ErrorMessage = "لطفا بستانکار را وارد کنید")]
        [Display(Name = "بستانکار")]
        public int Creditor { get; set; }
    }
}
