using MazOrganization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MazOrganization.Data
{
    public class MazgroupContext:IdentityDbContext
    {
        public MazgroupContext(DbContextOptions<MazgroupContext> options):base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<FieldInfo> FieldInfos { get; set; }
        public DbSet<PersonInfo> PersonInfos { get; set; }
        public DbSet<Referrals> Referrals { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
        public DbSet<report> reports { get; set; }
        public DbSet<Accounting> Accountings { get; set; }


    }
}
