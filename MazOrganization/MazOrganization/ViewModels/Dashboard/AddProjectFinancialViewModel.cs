using System.ComponentModel.DataAnnotations;

namespace MazOrganization.ViewModels.Dashboard
{
    public class AddProjectFinancialViewModel
    {
        public int ProjectId { get; set; }
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
