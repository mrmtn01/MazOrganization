using System.ComponentModel.DataAnnotations;

namespace MazOrganization.ViewModels.Dashboard
{
    public class ProjectFieldInfoViewModel
    {
        public int ProjectId { get; set; }
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
    }
}
