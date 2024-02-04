using MazOrganization.Repositories;
using MazOrganization.Models;
using MazOrganization.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Project = MazOrganization.Models.Project;
using Microsoft.AspNetCore.Identity;
using MazOrganization.ViewModels.UserManager;
using System.Data;
using Microsoft.Build.Evaluation;
using System.Globalization;
using Microsoft.VisualBasic;
using Financial = MazOrganization.Models.Financial;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Metadata;

namespace MazOrganization.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IProject _project;
        private IFieldInfo _fieldInfo;
        private IPersonInfo _personInfo;

        private IReferrals _referrals;
        private IProjectFile _projectFile;
        private IFinancial _financial;
      
        
        PersianCalendar pc = new PersianCalendar();

        private IWebHostEnvironment hostenv;
        private readonly UserManager<IdentityUser> _userManager;



        public ProjectController( IProject project, UserManager<IdentityUser> userManager, IWebHostEnvironment env, IFieldInfo fieldInfo, IPersonInfo personInfo, IProjectFile projectFile, IReferrals referrals, IFinancial financial)
        {
            _project = project;
            _personInfo = personInfo;
            _fieldInfo = fieldInfo;
            _userManager = userManager;

            _projectFile = projectFile;
            _referrals = referrals;
            _financial = financial;
            hostenv = env;
            
        }


        public IActionResult Index()
        {
            var sdsd = _project.GetProjectsIsDoneFalse();
            return View(sdsd);
        }


        public IActionResult Normal()
        {
            var Allproject = _project.GetAllProjects();
            var project = new List<NewShowProjectViewModel>();
            foreach (var item in Allproject)
            {
                var person = _personInfo.GetPersonInfoId(item.ProjectId);
                var field = _fieldInfo.GetFieldInfoId(item.ProjectId);
                var refrral = _referrals.GetReferralByReferralId(item.ReferralId);
                var finnacial = _financial.GetFinancialbyProjectid(item.ProjectId);
                var status = "";
                var Debtor = "";
                if (finnacial.Debtor == 0)
                {
                    Debtor = "تسویه شده";
                }
                else
                {
                    Debtor = "بدهکار";
                }

                if (item.IsDelete == true)
                {
                    status = "در انتظار تعیین وضعیت";
                }
                else if (item.IsDone == false && item.IsRaked == false)
                {
                    status = "در حال انجام";

                }
                else if (item.IsRaked == false && item.IsDone == true)
                {
                    status = "تکمیل شده";

                }
                else
                {
                    status = "راکد";
                }

                var newProject = new NewShowProjectViewModel()
                {
                    ProjectId = item.ProjectId,
                    PersonNo = person.PersonNo,
                    Address = field.Address,
                    CreateDate = item.CreateDate,
                    Fullname = person.FullName,
                    NationalCode = person.NationalCode,
                    ReferralsFullname = refrral.Fullname,
                    typeofapplication = item.typeofapplication,
                    Status = status,
                    Debtor = Debtor,
                };
                project.Add(newProject);
            }
            return View(project);

        }




        [HttpGet]
        public IActionResult AddProjectMain()
        {
            var referral = _referrals.GetAllReferrals();
            var users = _userManager.Users.ToList();

            ViewBag.ReferralId = new SelectList(referral, "ReferralId", "Fullname");
            //ViewBag.UserId = new SelectList(users, "Id", "UserName");

            return View(new AddprojectmaininfoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProjectMain(AddprojectmaininfoViewModel project)
        {
            if (project == null) NotFound();

            var referral = _referrals.GetReferralByReferralId(project.ReferralId);

            DateTime time = DateTime.Now;
            var date = new DateTime(pc.GetYear(time), pc.GetMonth(time), pc.GetDayOfMonth(time), pc.GetHour(time), pc.GetMinute(time), pc.GetSecond(time));

            var NewProject = new Project
            {
                ProjectName = project.ProjectName,
                Referralname = referral.Fullname,
                ReferralId = referral.ReferralId,
                CreateDate = date,
                IsDone = false,
                IsDelete = true,
                IsRaked = false,
                typeofapplication = project.typeofapplication
            };

            _project.AddProject(NewProject);
            _project.save();

            var NewPersonInfo = new PersonInfo
            {
                ProjectId = NewProject.ProjectId,
                FullName = project.FullName,
                FatherName = project.FatherName,
                BirthDate = project.BirthDate,
                Email = project.Email,
                NationalCode = project.NationalCode,
                PersonNo = project.PersonNo,
                Number = project.Number,
                PlaceIssue = project.PlaceIssue,
                TelNumber = project.TelNumber
            };

            _personInfo.AddPersonInfo(NewPersonInfo);

            var NewFieldInfo = new FieldInfo
            {
                ProjectId = NewProject.ProjectId,
                Sub = project.Sub,
                Address = project.Address,
                Assignor = project.Assignor,
                Assumed = project.Assumed,
                ContractNo = project.ContractNo,
                Foundation = project.Foundation,
                LandArea = project.LandArea,
                LandType = project.LandType,
                Main = project.Main,
                Piece = project.Piece,
                Registrationِepartment = project.Registrationِepartment,
                YektaCode = project.YektaCode
            };

            _fieldInfo.AddFieldInfo(NewFieldInfo);

            foreach (var item in project.ProjectFiles)
            {
                var filetype = item.formFile.ContentType;
                var parts = filetype.Split('/');
                var filetypefinal = parts[1];

                var fileproject = new ProjectFile()
                {
                    FileTittle = item.FileTittle,

                    typeFile = filetypefinal
                };

                _projectFile.AddFile(fileproject);


                var directoryPath = Directory.GetCurrentDirectory() + "/wwwroot" + "/Images/" + "Projects/" + NewProject.ProjectId;
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var filePath = Path.Combine(directoryPath, fileproject.FileId + "." + filetypefinal);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    item.formFile.CopyTo(stream);
                }
            }

            var financial = new Financial()
            {
                Debtor = 0,
                Creditor = 0,
                ProjectId = NewProject.ProjectId,
                TotalAmount = 0
            };
            _financial.AddFinancial(financial);
            _project.save();



            return RedirectToAction("Normal");



        }








        [HttpGet]
        public IActionResult EditProjectMain(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }


            Project project = _project.GetProjectsWithId(projectId.Value);


            if (project == null)
            {
                return NotFound();
            }

            var viewmodel = new EditprojectmaininfoViewModel()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ReferralId = project.ReferralId,
                ReferralName = project.Referralname,
                typeofapplication = project.typeofapplication,
                CreateDate = project.CreateDate,
                IsDelete = project.IsDelete,
                IsDone = project.IsDone
            };

            ViewBag.ReferralId = new SelectList(_referrals.GetAllReferrals(), "ReferralId", "Fullname", viewmodel.ReferralId);
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjectMain(EditprojectmaininfoViewModel project)
        {
            if (project == null) NotFound();

            var referral = _referrals.GetReferralByReferralId(project.ReferralId);


            var editProject = new Project()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ReferralId = referral.ReferralId,
                Referralname = referral.Fullname,
                IsDelete = project.IsDelete,
                IsDone = project.IsDone,
                CreateDate = project.CreateDate,
                typeofapplication = project.typeofapplication
            };

            _project.EditProject(editProject);
            _project.save();

            return RedirectToAction("EditProjectDepartment", new { projectId = editProject.ProjectId });
        }


        [HttpGet]
        public IActionResult EditProjectDepartment(int? projectId)
        {
            if (projectId == null) return NotFound();

            var project = _project.GetProjectsWithId(projectId.Value);
            if (project == null) return NotFound();

            var model = new AddProjectToDepartmentsViewModel() { ProjectId = projectId.Value };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjectDepartment(AddProjectToDepartmentsViewModel model)
        {
            if (model == null) return NotFound();
            var project = _project.GetProjectsWithId(model.ProjectId);
            if (project == null) return NotFound();
            var DepartmentsId = model.ProjectDepartments.Where(r => r.IsSelected == true)
                .ToList();







            return RedirectToAction("EditProjectPersonInfo", new { ProjectId = project.ProjectId });

        }




        [HttpGet]
        public IActionResult EditProjectPersonInfo(int? ProjectId)
        {
            if (ProjectId == null)
            {
                return NotFound();
            }

            var PersonInfo = _personInfo.GetPersonInfoId(ProjectId.Value);

            if (PersonInfo == null)
            {
                return NotFound();
            }

            var edit = new ProjectPersonInfoViewModel()
            {
                ProjectId = PersonInfo.ProjectId,
                BirthDate = PersonInfo.BirthDate,
                Email = PersonInfo.Email,
                FatherName = PersonInfo.FatherName,
                FullName = PersonInfo.FullName,
                NationalCode = PersonInfo.NationalCode,
                Number = PersonInfo.Number,
                PersonInfoId = PersonInfo.InfoId,
                PersonNo = PersonInfo.PersonNo,
                PlaceIssue = PersonInfo.PlaceIssue,
                TelNumber = PersonInfo.TelNumber
            };

            return View(edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjectPersonInfo(ProjectPersonInfoViewModel project, int projectId)
        {
            if (project == null) NotFound();

            var NewPersonInfo = new PersonInfo
            {
                ProjectId = projectId,
                FullName = project.FullName,
                FatherName = project.FatherName,
                BirthDate = project.BirthDate,
                Email = project.Email,
                NationalCode = project.NationalCode,
                PersonNo = project.PersonNo,
                Number = project.Number,
                PlaceIssue = project.PlaceIssue,
                TelNumber = project.TelNumber,
                InfoId = project.PersonInfoId
            };

            _personInfo.EditPersonInfo(NewPersonInfo);
            _project.save();

            return RedirectToAction("EditProjectFieldInfo", new { projectid = projectId });
        }


        [HttpGet]
        public IActionResult EditProjectFieldInfo(int? projectid)
        {
            if (projectid == null)
            {
                return NotFound();
            }

            var filedInfo = _fieldInfo.GetFieldInfoId(projectid.Value);


            if (filedInfo == null)
            {
                return NotFound();
            }

            var edit = new ProjectFieldInfoViewModel()
            {
                ProjectId = filedInfo.ProjectId,
                Sub = filedInfo.Sub,
                Address = filedInfo.Address,
                Assignor = filedInfo.Assignor,
                Assumed = filedInfo.Assumed,
                ContractNo = filedInfo.ContractNo,
                FieldInfoId = filedInfo.FieldId,
                Foundation = filedInfo.Foundation,
                LandArea = filedInfo.LandArea,
                LandType = filedInfo.LandType,
                Main = filedInfo.Main,
                Piece = filedInfo.Piece,
                Registrationِepartment = filedInfo.Registrationِepartment
            };

            return View(edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjectFieldInfo(ProjectFieldInfoViewModel project, int projectid)
        {
            if (project == null) NotFound();

            var NewFieldInfo = new FieldInfo
            {
                ProjectId = projectid,
                Sub = project.Sub,
                Address = project.Address,
                Assignor = project.Assignor,
                Assumed = project.Assumed,
                ContractNo = project.ContractNo,
                Foundation = project.Foundation,
                LandArea = project.LandArea,
                LandType = project.LandType,
                Main = project.Main,
                Piece = project.Piece,
                Registrationِepartment = project.Registrationِepartment,
                FieldId = project.FieldInfoId
            };

            _fieldInfo.EditFieldInfo(NewFieldInfo);
            _fieldInfo.save();

            return RedirectToAction("EditProjectFinancial", new { projectid = projectid });

        }


        [HttpGet]
        public IActionResult EditProjectFinancial(int? projectid)
        {
            if (projectid == null)
            {
                return NotFound();
            }

            var financial = _financial.GetFinancialbyProjectid(projectid.Value);


            if (financial == null)
            {
                return NotFound();
            }

            var edit = new AddProjectFinancialViewModel()
            {
                Creditor = financial.Creditor,
                Debtor = financial.Debtor,
                ProjectId = projectid.Value,
                TotalAmount = financial.TotalAmount,
                financialId = financial.FinancialId
            };



            return View(edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjectFinancial(AddProjectFinancialViewModel project, int projectid)
        {
            if (project == null) NotFound();

            var financial = new Financial()
            {
                ProjectId = projectid,
                Debtor = project.Debtor,
                Creditor = project.Creditor,
                TotalAmount = project.TotalAmount,
                FinancialId = project.financialId
            };

            _financial.EditFinancial(financial);

            try
            {
                _financial.Save();
            }
            catch
            {

                throw;
            }

            return RedirectToAction("Normal", "Project", new { Isdone = false });


        }



        //[HttpGet]
        //public IActionResult AddProjectFile(int id)
        //{



        //    return View();
        //}


        //[HttpPost]
        //public IActionResult AddProjectFile(int id, IFormFile files)
        //{
        //    if (HttpContext.Request.Form.Files.Count > 0)
        //    {
        //        var directoryPath = Directory.GetCurrentDirectory() + "/wwwroot" + "/ProjectFiles/";
        //        if (!Directory.Exists(directoryPath))
        //        {
        //            Directory.CreateDirectory(directoryPath);
        //        }

        //        var files = HttpContext.Request.Form.Files;

        //        foreach (var file in files)
        //        {
        //            var filePath = Path.Combine(directoryPath, file.FileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //        }


        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");
        //}






        public IActionResult ShowProject(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }

            Project project = _project.GetProjectsWithId(projectId.Value);


            if (project == null)
            {
                return NotFound();
            }
            ViewData["id"] = projectId;


            PersonInfo person = _personInfo.GetPersonInfoId(projectId.Value);
            FieldInfo field = _fieldInfo.GetFieldInfoId(projectId.Value);
            Financial financial = _financial.GetFinancialbyProjectid(projectId.Value);

            DateTime time = project.CreateDate;
            string PersianDate = string.Format("{0}/{1}/{2}", time.Year, time.Month, time.Day);




            var pro = new ShowProjectViewModel()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                CreateDate = PersianDate,
                IsDelete = project.IsDelete,
                IsDone = project.IsDone,
                ReferralId = project.ReferralId,
                ReferralName = project.Referralname,
                typeofapplication = project.typeofapplication,
                Sub = field.Sub,
                Address = field.Address,
                Assignor = field.Assignor,
                Assumed = field.Assumed,
                BirthDate = person.BirthDate,
                ContractNo = field.ContractNo,
                Creditor = financial.Creditor,
                Debtor = financial.Debtor,
                Email = person.Email,
                FatherName = person.FatherName,
                FieldInfoId = field.FieldId,
                financialId = financial.FinancialId,
                Foundation = field.Foundation,
                FullName = person.FullName,
                LandArea = field.LandArea,
                LandType = field.LandType,
                Main = field.Main,
                NationalCode = person.NationalCode,
                Number = person.Number,
                PersonInfoId = person.InfoId,
                PersonNo = person.PersonNo,
                Piece = field.Piece,
                PlaceIssue = person.PlaceIssue,
                Registrationِepartment = field.Registrationِepartment,
                TelNumber = person.TelNumber,
                TotalAmount = financial.TotalAmount
            };




            return View(pro);
        }

        public IActionResult IsDoneProject(int projectId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Normal", "Project", new { Isdone = false });

            }
            _project.IsDoneProject(projectId);

            return RedirectToAction("Normal", "Project", new { Isdone = false });


        }
        public IActionResult RemoveProject(int projectId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Normal", "Project", new { Isdone = false });


            }
            _project.IsDeleteProject(projectId);

            return RedirectToAction("Normal", "Project", new { Isdone = false });


        }




    }
}
