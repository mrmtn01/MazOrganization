using MazOrganization.Data;
using MazOrganization.Models;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface ILog
    {
        IEnumerable<Log> GetAllLogs();
        IEnumerable<Log> GetLogsbyUserId(int userId);
        void AddLog(Log log);
        void Save();
    }


    public class LogRepository : ILog
    {

        private MazgroupContext _context;

        public LogRepository(MazgroupContext context)
        {
            _context = context;
        }


        public void AddLog(Log log)
        {
            _context.Logs.Add(log);
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return _context.Logs.ToList();
        }

        public IEnumerable<Log> GetLogsbyUserId(int userId)
        {
            return _context.Logs.Where(l => l.UserId == userId).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
