using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IPersonInfo
    {
        void AddPersonInfo(PersonInfo personInfo);
        PersonInfo GetPersonInfoId(int id);
        void EditPersonInfo(PersonInfo personInfo);
        void RemovePersonInfo(PersonInfo personInfo);
        void save();
    }

    public class PersonInfoRepository : IPersonInfo
    {
        private MazgroupContext _context;

        public PersonInfoRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void AddPersonInfo(PersonInfo personInfo)
        {
            _context.PersonInfos.Add(personInfo);
        }

        public void EditPersonInfo(PersonInfo personInfo)
        {
            _context.Entry(personInfo).State = EntityState.Modified;
        }

        public PersonInfo GetPersonInfoId(int id)
        {
            return _context.PersonInfos.SingleOrDefault(p=>p.ProjectId == id);
        }

        public void RemovePersonInfo(PersonInfo personInfo)
        {
            _context.Entry(personInfo).State = EntityState.Deleted;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
