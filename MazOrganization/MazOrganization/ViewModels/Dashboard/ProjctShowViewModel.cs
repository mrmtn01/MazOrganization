using MazOrganization.Models;
using System.Collections.Generic;

namespace MazOrganization.ViewModels.Dashboard
{
    public class ProjctShowViewModel
    {
        public IEnumerable<Project> IsDoneFalse { get; set; }
        public IEnumerable<Project> IsDoneTrue { get; set; }
    }
}
