using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IProject
    {
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Project> GetProjectsIsDoneFalse();
        IEnumerable<Project> GetProjectsIsDoneTrue();
        IEnumerable<Project> GetProjectsIsRaketTrue();
        IEnumerable<Project> GetProjectsWithDepartment(int departmentId);
        Project GetProjectsWithId(int projectId);
        void AddProject(Project project);
        void RemoveProject(int id);
        void EditProject(Project project);

        void IsDoneProject(int id);
        void IsDeleteProject(int id);
        void IsDeleteProjectoff(int id);
        void IsRaketProject(int id);

        void IsRaketProjectoff(int id);

        void save();
    }

    public class ProjectRepository : IProject
    {
        private MazgroupContext _context;

        public ProjectRepository(MazgroupContext context)
        {
            _context = context;
        }
        public void IsDoneProject(int id)
        {
            var project = _context.Projects.Find(id);
            project.IsDone = true;
            save();
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void EditProject(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Project> GetProjectsIsDoneFalse()
        {
            return _context.Projects.Where(p => p.IsDone == false && p.IsDelete == false && p.IsRaked == false).ToList();
        }

        public IEnumerable<Project> GetProjectsIsDoneTrue()
        {
            return _context.Projects.Where(p => p.IsDone == true && p.IsDelete == false && p.IsRaked == false).ToList();
        }

        public IEnumerable<Project> GetProjectsWithDepartment(int departmentId)
        {
            //return _context.Projects.Where(p => p.DepartmentId == departmentId).ToList();
            return _context.Projects.ToList();
        }

        public Project GetProjectsWithId(int projectId)
        {
            return _context.Projects.SingleOrDefault(p => p.ProjectId == projectId);
        }

        

        public void save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Project> GetProjectsIsRaketTrue()
        {
            return _context.Projects.Where(p => p.IsRaked == true).ToList();

        }

        public void RemoveProject(int id)
        {
            var project = _context.Projects.Find(id);
            project.IsDelete = true;
            save();
        }

        public void IsDeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            project.IsDelete = true;
            save();
        }

        public void IsDeleteProjectoff(int id)
        {
            var project = _context.Projects.Find(id);
            project.IsDelete = false;
            save();
        }

        public void IsRaketProject(int id)
        {
            var project = _context.Projects.Find(id);
            project.IsRaked = true;
            save();
        }

        public void IsRaketProjectoff(int id)
        {
            var project = _context.Projects.Find(id);
            project.IsRaked = false;
            save();
        }
    }
}
