
using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IFinancial
    {
        Financial GetFinancialbyProjectid(int projectid);
        Financial GetFinancialbyid(int financialid);
        void AddFinancial(Financial financial);
        void RemoveFinancial(Financial referral);
        void EditFinancial(Financial financial);
        void Save();
    }


    public class FinancialRepository : IFinancial
    {

        private MazgroupContext _context;

        public FinancialRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void AddFinancial(Financial financial)
        {
            _context.Financials.Add(financial);
        }

        public void EditFinancial(Financial financial)
        {
            _context.Entry(financial).State = EntityState.Modified;
        }

        public Financial GetFinancialbyid(int financialid)
        {
            return _context.Financials.SingleOrDefault(f => f.FinancialId == financialid);
        }

        public Financial GetFinancialbyProjectid(int projectid)
        {
            return _context.Financials.SingleOrDefault(f => f.ProjectId == projectid);
        }

        public void RemoveFinancial(Financial referral)
        {
            _context.Entry(referral).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
