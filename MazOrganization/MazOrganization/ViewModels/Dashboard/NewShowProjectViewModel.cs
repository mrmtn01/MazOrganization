using System;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.ViewModels.Dashboard
{
    public class NewShowProjectViewModel
    {
        public int ProjectId { get; set; }
        public string Fullname { get; set; }
        public string ReferralsFullname { get; set; }

        public string Status {  get; set; }
        public DateTime CreateDate { get; set; }
        public string NationalCode { get; set; }
        public string PersonNo { get; set; }
        public string Address { get; set; }
        public string Debtor { get; set; }
        public string typeofapplication { get; set; }


    }
}
