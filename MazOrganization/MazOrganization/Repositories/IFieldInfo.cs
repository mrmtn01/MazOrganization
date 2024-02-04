using MazOrganization.Data;
using MazOrganization.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MazOrganization.Repositories
{
    public interface IFieldInfo
    {
        void AddFieldInfo(FieldInfo fieldInfo);
        FieldInfo GetFieldInfoId(int id);
        void RemoveFieldInfo(FieldInfo fieldInfo);
        void EditFieldInfo(FieldInfo fieldInfo);
        void save();
    }

    public class FieldInfoRepository : IFieldInfo
    {

        private MazgroupContext _context;

        public FieldInfoRepository(MazgroupContext context)
        {
            _context = context;
        }

        public void AddFieldInfo(FieldInfo fieldInfo)
        {
            _context.FieldInfos.Add(fieldInfo);
        }

        public void EditFieldInfo(FieldInfo fieldInfo)
        {
            _context.Entry(fieldInfo).State = EntityState.Modified;
        }

        public FieldInfo GetFieldInfoId(int id)
        {
            return _context.FieldInfos.SingleOrDefault(p => p.ProjectId == id);
        }

        public void RemoveFieldInfo(FieldInfo fieldInfo)
        {
            _context.Entry(fieldInfo).State = EntityState.Deleted;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
