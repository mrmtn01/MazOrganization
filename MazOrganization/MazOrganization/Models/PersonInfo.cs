using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class PersonInfo
    {
        [Key]
        public int InfoId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required(ErrorMessage ="لطفا نام و نام خانوادگی را وارد کنید")]
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا نام پدر را وارد کنید")]
        [Display(Name = "نام پدر")]
        [MaxLength(50)]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "لطفا محل صدور را وارد کنید")]
        [Display(Name = "محل صدور")]
        [MaxLength(50)]
        public string PlaceIssue { get; set; }

        [Required(ErrorMessage = "لطفا شماره شناسنامه را وارد کنید")]
        [Display(Name = "شماره شناسنامه")]
        [MaxLength(50)]
        public string PersonNo { get; set; }

        [Required(ErrorMessage = "لطفا کدملی را وارد کنید")]
        [Display(Name = "کدملی")]
        [MaxLength(50)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        [MaxLength(100)]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "لطفا شماره همراه را وارد کنید")]
        [Display(Name = "شماره همراه")]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required(ErrorMessage = "لطفا تلفن ثابت را وارد کنید")]
        [Display(Name = "تلفن ثابت")]
        [MaxLength(50)]
        public string TelNumber { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100)]
        public string Email { get; set; }


        public Project project { get; set; }
    }
}
