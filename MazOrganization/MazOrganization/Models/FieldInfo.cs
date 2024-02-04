using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class FieldInfo
    {
        [Key]
        public int FieldId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "لطفا آدرس را وارد کنید")]
        [Display(Name ="آدرس")]
        [DataType(DataType.MultilineText)]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "لطفا مساحت زمین را وارد کنید")]
        [Display(Name = "مساحت زمین")]
        [MaxLength(50)]
        public string LandArea { get; set; }

        [Display(Name = "زیربنا")]
        [MaxLength(50)]
        public string Foundation { get; set; }

        [Display(Name = "نوع زمین")]
        [MaxLength(50)]
        public string LandType { get; set; }

        [Display(Name = "بخش ثبتی")]
        [MaxLength(50)]
        public string Registrationِepartment { get; set; }

        [Display(Name = "مفروز")]
        [MaxLength(50)]
        public string Assumed { get; set; }

        [Display(Name = "قطعه")]
        [MaxLength(50)]
        public string Piece { get; set; }

        [Display(Name = "اصلی")]
        [MaxLength(50)]
        public string Main { get; set; }

        [Display(Name = "فرعی")]
        [MaxLength(50)]
        public string Sub { get; set; }

        [Display(Name = "شماره قرارداد")]
        [MaxLength(50)]
        public string ContractNo { get; set; }

        [Display(Name = "واگذر کننده")]
        [MaxLength(50)]
        public string Assignor { get; set; }

        [Display(Name = "کدیکتا")]
        [MaxLength(50)]
        public string YektaCode { get; set; }


        public Project project { get; set; }

    }
}
