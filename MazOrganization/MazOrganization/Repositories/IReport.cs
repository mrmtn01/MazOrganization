using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace MazOrganization.Repositories
{
    public interface IReport
    {
        IEnumerable<report> GetAllreportByProjectId(int Projectid);
        IEnumerable<report> GetAllreportByUserId(int Userid);
        report GetreportById(int id);
        void Editreport(report report);
        void Removereport(report report);
        void Addreport(report report);
        void Save();
    }

    public class ReportRepository : IReport
    {
        private MazgroupContext _context;
        public ReportRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void Addreport(report report)
        {
            _context.reports.Add(report);
        }

        public void Editreport(report report)
        {
            _context.Entry(report).State = EntityState.Modified;
        }

        public IEnumerable<report> GetAllreportByProjectId(int Projectid)
        {
            return _context.reports.Where(r=>r.projectId == Projectid).ToList();
        }

        public IEnumerable<report> GetAllreportByUserId(int Userid)
        {
            return _context.reports.Where(r => r.userId == Userid).ToList();
        }

        public report GetreportById(int id)
        {
            return _context.reports.SingleOrDefault(c=>c.reportId == id);
        }

        public void Removereport(report report)
        {
            _context.Entry(report).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
