using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IAccounting
    {
        IEnumerable<Accounting> GetAllAccountsByProjectId(int Projectid);
        IEnumerable<Accounting> GetAllAccountsByUserId(int Userid);
        Accounting GetAccountById(int id);
        void EditAccount(Accounting account);
        void RemoveAccount(Accounting account);
        void AddAccount(Accounting account);
        void Save();

    }

    public class AccountingRepository : IAccounting
    {
        private MazgroupContext _context;
        
        public AccountingRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void AddAccount(Accounting account)
        {
            _context.Accountings.Add(account);
        }

        public void EditAccount(Accounting account)
        {
            _context.Entry(account).State = EntityState.Modified;
        }

        public Accounting GetAccountById(int id)
        {
            return _context.Accountings.SingleOrDefault(c=>c.accountingId == id);
        }

        public IEnumerable<Accounting> GetAllAccountsByProjectId(int Projectid)
        {
            return _context.Accountings.Where(c=>c.projectId == Projectid).ToList();
        }

        public IEnumerable<Accounting> GetAllAccountsByUserId(int Userid)
        {
            return _context.Accountings.Where(a=>a.userId == Userid).ToList();
        }

        public void RemoveAccount(Accounting account)
        {
            _context.Entry(account).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
