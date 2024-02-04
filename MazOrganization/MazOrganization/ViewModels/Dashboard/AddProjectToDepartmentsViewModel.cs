using System.Collections.Generic;

namespace MazOrganization.ViewModels.Dashboard
{
    public class AddProjectToDepartmentsViewModel
    {

        public AddProjectToDepartmentsViewModel()
        {
            ProjectDepartments = new List<ProjectDepartmentViewModel>();
        }

        public int ProjectId { get; set; }

        public List<ProjectDepartmentViewModel> ProjectDepartments { get; set; }
    }

    public class ProjectDepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsSelected { get; set; }
    }



}
