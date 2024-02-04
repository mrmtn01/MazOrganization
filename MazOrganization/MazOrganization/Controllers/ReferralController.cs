using MazOrganization.Models;
using MazOrganization.Repositories;
using MazOrganization.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace MazOrganization.Controllers
{
    [Authorize]

    public class ReferralController : Controller
    {
        private IReferrals _referral;
        private IProject _project;

        public ReferralController(IReferrals referrals, IProject project)
        {
            _referral = referrals;
            _project = project;
        }
        public IActionResult Index()
        {
            var referrals = _referral.GetAllReferrals();
            List<ReferralDViewmodel> referrals1 = new List<ReferralDViewmodel>();
            foreach (var referral in referrals)
            {
                var refs = new ReferralDViewmodel()
                {
                    ReferralId = referral.ReferralId,
                    ReferralName = referral.Fullname,
                    Count = _project.GetAllProjects().Where(n =>n.ReferralId == referral.ReferralId).Count()
                };
                referrals1.Add(refs);
              
            }
            return View(referrals1);
        }


        [HttpGet]
        public IActionResult AddReferrals()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReferrals(ReferralsViewModel referrals)
        {
            var Newreferrals = new Referrals
            {
                Fullname = referrals.Fullname,
                NationalNumber = referrals.NationalNumber,
                MobileNumber = referrals.MobileNumber,
                Address = referrals.Address
            };

            _referral.AddReferral(Newreferrals);
            _referral.Save();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult EditReferrals(int? referralId)
        {
            if (referralId == null)
            {
                return NotFound();
            }

            Referrals referral = _referral.GetReferralByReferralId(referralId.Value);


            if (referral == null)
            {
                return NotFound();
            }




            var ReferralView = new ReferralsViewModel()
            {
                Fullname= referral.Fullname,
                MobileNumber= referral.NationalNumber,
                NationalNumber= referral.NationalNumber,
                Address= referral.Address,
                ReferralId = referral.ReferralId
            };

            return View(ReferralView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditReferrals(ReferralsViewModel referrals)
        {
            var editreferral = new Referrals()
            {
                Fullname = referrals.Fullname,
                MobileNumber= referrals.NationalNumber,
                NationalNumber= referrals.NationalNumber, 
                Address= referrals.Address,
                ReferralId= referrals.ReferralId
            };

            _referral.EditReferral(editreferral);
            _referral.Save();

            return RedirectToAction("Index");
        }


        public IActionResult RemoveReferrals(int? referralId)
        {
            if (referralId == null)
            {
                return NotFound();
            }


            var Referral = _referral.GetReferralByReferralId(referralId.Value);


            _referral.RemoveReferral(Referral);
            _referral.Save();


            return RedirectToAction("Index");
        }

        public IActionResult ShowReferrals(int? referralId)
        {
            ViewData["id"] = referralId;

            if (referralId == null)
            {
                return NotFound();
            }

            Referrals referral = _referral.GetReferralByReferralId(referralId.Value);


            if (referral == null)
            {
                return NotFound();
            }




            var ReferralView = new ReferralsViewModel()
            {
                Fullname = referral.Fullname,
                MobileNumber = referral.NationalNumber,
                NationalNumber = referral.NationalNumber,
                Address = referral.Address
            };

            return View(ReferralView);
        }
    }
}
