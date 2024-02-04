using System;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        [Display(Name = "کاربر")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "فعالیت انجام شده")]
        public string Task { get; set; }

        [Required]
        [Display(Name = "تاریخ فعالیت")]
        public DateTime Date { get; set; }
    }
}
