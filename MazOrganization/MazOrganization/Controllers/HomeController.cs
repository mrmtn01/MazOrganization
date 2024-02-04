using MazOrganization.Models;
using MazOrganization.Repositories;
using MazOrganization.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MazOrganization.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProject _project;
        private IFieldInfo _fieldInfo;
        private IPersonInfo _personInfo;
       
        private IReferrals _referrals;
        private IProjectFile _projectFile;
        private IFinancial _financial;
        private readonly UserManager<IdentityUser> _userManager;


        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IProject project, IFieldInfo fieldInfo, IPersonInfo personInfo, IProjectFile projectFile, IReferrals referrals, IFinancial financial)
        {
            _logger = logger;
            _project = project;
            _personInfo = personInfo;
            _fieldInfo = fieldInfo;
          
            _projectFile = projectFile;
            _referrals = referrals;
            _financial = financial;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["Project"] = _project.GetAllProjects().Count();
            
            ViewData["Referral"] = _referrals.GetAllReferrals().Count();
            ViewData["Account"] = _userManager.Users.Count();
            ViewData["IsDoneProject"] = _project.GetProjectsIsDoneTrue().Count();
            ViewData["NormalProject"] = _project.GetProjectsIsDoneFalse().Count();

          


            DashboardDepartmentViewModel[] model = {};

           



            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        

    }
}
