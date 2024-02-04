using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class Financial
    {
        [Key]
        public int FinancialId { get; set; }

        [Required(ErrorMessage = "لطفا پروژه را وارد کنید")]
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }

        [Display(Name = "مبلغ کل")]
        public int TotalAmount { get; set; }

        [Display(Name = "بدهکار")]
        public int Debtor { get; set; }

        [Display(Name = "بستانکار")]
        public int Creditor { get; set; }


        public Project project { get; set; }
    }
}
