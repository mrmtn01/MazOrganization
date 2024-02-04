using MazOrganization.Models;
using MazOrganization.Repositories;
using MazOrganization.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace MazOrganization.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private IProject _project;
        private IFieldInfo _fieldInfo;
        private IPersonInfo _personInfo;
  
        private IReferrals _referrals;
        private IProjectFile _projectFile;
        private IFinancial _financial;


        public UploadController(IProject project, IFieldInfo fieldInfo, IPersonInfo personInfo, IProjectFile projectFile, IReferrals referrals, IFinancial financial)
        {
            _project = project;
            _personInfo = personInfo;
            _fieldInfo = fieldInfo;
         
            _projectFile = projectFile;
            _referrals = referrals;
            _financial = financial;
        }


        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Index(UploadViewModel model)
        {
            if (model == null) return NotFound();


            var filetype = model.formFile.ContentType;
            var parts = filetype.Split('/');
            var filetypefinal = parts[1];

            var fileproject = new ProjectFile()
            {
                FileTittle = model.FileTittle,
                
                typeFile = filetypefinal
            };

            _projectFile.AddFile(fileproject);
            _projectFile.Save();


            var directoryPath = Directory.GetCurrentDirectory() + "/wwwroot" + "/Images/" + "Projects/";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var filePath = Path.Combine(directoryPath, fileproject.FileId + "." + filetypefinal);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.formFile.CopyTo(stream);
            }



            return RedirectToAction("Normal", "Project",new {Isdone = false});
        }



        public IActionResult Show(int id)
        {
            ViewData["path"] = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Projects" , id.ToString());
            var files = _projectFile.GetProjectFilebyProjectId(id);
            ViewData["id"] = id;
            return View(files);
        }


        public IActionResult Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var file = _projectFile.GetProjectFile(id);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Projects", file.ProjectId.ToString(), file.FileId + "." + file.typeFile);
            _projectFile.RemoveFile(file);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _projectFile.Save();
            return RedirectToAction("Show", new { id = file.ProjectId });
        }



        public IActionResult Download(int id)
        {
            ProjectFile file = _projectFile.GetProjectFile(id);
            string filename = id.ToString() + "." + file.typeFile;
            string filepath = $"wwwroot/Images/Projects/{file.ProjectId}/" + filename;
            var filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.MimeUtility.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true
            };


            return File(filedata, contentType);

        }
    }





}
