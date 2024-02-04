using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IReferrals
    {
        IEnumerable<Referrals> GetAllReferrals();
        Referrals GetReferralByReferralId(int referralid);
        void AddReferral(Referrals referral);
        void RemoveReferral(Referrals referral);
        void EditReferral(Referrals referral);
        void Save();
    }


    public class ReferralsRepository : IReferrals
    {

        private MazgroupContext _context;

        public ReferralsRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void AddReferral(Referrals referral)
        {
            _context.Referrals.Add(referral);
        }

        public void EditReferral(Referrals referral)
        {
            _context.Entry(referral).State = EntityState.Modified;
        }

        public IEnumerable<Referrals> GetAllReferrals()
        {
            return _context.Referrals.ToList();
        }

        public Referrals GetReferralByReferralId(int referralid)
        {
            return _context.Referrals.SingleOrDefault(r => r.ReferralId == referralid);
        }

        public void RemoveReferral(Referrals referral)
        {
            _context.Entry(referral).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
