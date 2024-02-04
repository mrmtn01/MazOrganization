using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "لطفا نام پروژه را وارد کنید")]
        [Display(Name ="نام پروژه")]
        public string ProjectName { get; set; }


        [Required(ErrorMessage = "لطفا معرف پروژه را وارد کنید")]
        [Display(Name = "معرف پروژه")]
        public int ReferralId { get; set; }

        [Required(ErrorMessage = "لطفا معرف پروژه را وارد کنید")]
        [Display(Name = "معرف پروژه")]
        public string Referralname { get; set; }

        
        [Display(Name = "نوع درخواست")]
        public string typeofapplication { get; set; }


        [Required]
        [Display(Name = "تاریخ ایجاد پروژه")]
        public DateTime CreateDate{ get; set; }


        [Display(Name = "وضعیت پروژه")]
        public bool IsDone { get; set; }

        [Display(Name = "وضعیت حذف")]
        public bool IsDelete { get; set; }

        [Display(Name = "وضعیت راکد")]
        public bool IsRaked { get; set; }

        public Referrals referrals { get; set; }
        public Financial financial { get; set; }
        public PersonInfo personInfo { get; set; }
        public FieldInfo fieldInfo { get; set; }
        public ICollection<ProjectFile> projectFiles { get; set; }
        public ICollection<Accounting> accountings { get; set; }
        public ICollection<report> reports { get; set; }
    }
}
