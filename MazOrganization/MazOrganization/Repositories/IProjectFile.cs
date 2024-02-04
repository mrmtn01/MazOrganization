using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IProjectFile
    {
        IEnumerable<ProjectFile> GetProjectFilebyProjectId(int projectid);
        ProjectFile GetProjectFile(int fileid);
        void AddFile(ProjectFile file);
        void RemoveFile(ProjectFile file);
        void Save();
    }

    public class ProjectFileRepository : IProjectFile
    {
        private MazgroupContext _context;

        public ProjectFileRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void AddFile(ProjectFile file)
        {
            _context.ProjectFiles.Add(file);
        }

        public ProjectFile GetProjectFile(int fileid)
        {
            return _context.ProjectFiles.SingleOrDefault(p=>p.FileId == fileid);
        }

        public IEnumerable<ProjectFile> GetProjectFilebyProjectId(int projectid)
        {
            return _context.ProjectFiles.Where(p => p.ProjectId == projectid).ToList();
        }

        public void RemoveFile(ProjectFile file)
        {
            _context.Entry(file).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
