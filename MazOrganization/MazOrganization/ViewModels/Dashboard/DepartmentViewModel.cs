using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MazOrganization.ViewModels.Dashboard
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "لطفا نام دپارتمان را وارد کنید")]
        [Display(Name = "نام دپارتمان")]
        public string DepartmentName { get; set; }
    }
}
