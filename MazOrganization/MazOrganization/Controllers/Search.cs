using MazOrganization.Models;
using MazOrganization.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Controllers
{
    [Authorize]

    public class Search : Controller
    {
        private IProject _project;
        private IFieldInfo _fieldInfo;
        private IPersonInfo _personInfo;
        
        private IReferrals _referrals;
        private IProjectFile _projectFile;
        private IFinancial _financial;


        public Search(IProject project, IFieldInfo fieldInfo, IPersonInfo personInfo, IProjectFile projectFile, IReferrals referrals, IFinancial financial)
        {
            _project = project;
            _personInfo = personInfo;
            _fieldInfo = fieldInfo;
           
            _projectFile = projectFile;
            _referrals = referrals;
            _financial = financial;
        }


        public IActionResult Index(string search)
        {
            var model = _project.GetAllProjects();
            ViewData["search"] = search;
            if (!string.IsNullOrEmpty(search))
            {
                var model2 = model.Where(m => m.ProjectName.Contains(search)).ToList();
                return View(model2);

            }
            else
            {
                return View(model);
            }
        }



        public IActionResult Referral(int id)
        {
            var model = _project.GetAllProjects().Where(m=>m.ReferralId ==  id).ToList();
            string Referralname = _referrals.GetReferralByReferralId(id).Fullname;
            ViewData["referral"] = Referralname;
            
            return View(model);

        }
    }
}
