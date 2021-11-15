using Exam_Management.Models.ViewModels;
using Exam_Management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Controllers
{
    public class ExamSiteController : Controller
    {
        public IExamSiteRepo _examSiteRepo;
        public ExamSiteController(IExamSiteRepo examSiteRepo)
        {
            _examSiteRepo = examSiteRepo;
        }

        public ActionResult Index()
        {
            var sites = _examSiteRepo.GetAll();
            var siteViewModel = sites.Select(s => new ExamSiteViewModel(s));

            return View(siteViewModel);
        }

        public ActionResult Details(int id)
        {
            var site = _examSiteRepo.GetExamSiteById(id);
            var siteViewModel = new ExamSiteViewModel(site);

            return View(siteViewModel);
        }

        public ActionResult CreateSite()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var code = collection["Code"];
            var name = collection["Name"];

            try
            {
                var site = new ExamSiteViewModel()
                {
                    Code = code,
                    Name = name
                };

                _examSiteRepo.AddExamSite(site);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var siteId = collection["id"];
            var code = collection["Code"];
            var name = collection["Name"];

            try
            {
                var site = new ExamSiteViewModel()
                {
                    Id = id,
                    Code = code,
                    Name = name
                };

                _examSiteRepo.UpdateExamSite(site);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamSite/Delete/5
        public ActionResult Delete(int id)
        {
            var dbmodel = _examSiteRepo.GetExamSiteById(id);
            var view = new ExamSiteViewModel(dbmodel);
            return View(view);
        }

        // POST: ExamSite/Delete/5
        [HttpPost]
        public ActionResult DeleteSite(ExamSiteViewModel site)
        {
            try
            {
                _examSiteRepo.DeleteExamSite(site.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
