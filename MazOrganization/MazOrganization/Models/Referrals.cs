using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class Referrals
    {
        [Key]
        public int ReferralId { get; set; }


        [Required(ErrorMessage = "لطفا نام و نام خانوادگی را وارد کنید")]
        [Display(Name = "نام و نام خانوادگی")]
        public string Fullname { get; set; }


        [Required(ErrorMessage = "لطفا شماره ملی را وارد کنید")]
        [Display(Name = "شماره ملی")]
        public string NationalNumber { get; set; }


        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        [Display(Name = "شماره موبایل")]
        public string MobileNumber { get; set; }


        [Required(ErrorMessage = "لطفا آدرس را وارد کنید")]
        [Display(Name = "آدرس")]
        
        public string Address { get; set; }


        public ICollection<Project> projects { get; set; }
    }
}
