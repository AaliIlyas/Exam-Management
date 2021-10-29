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
    public class ExamSite : Controller
    {
        public IExamSiteRepo _examSiteRepo;
        public ExamSite(IExamSiteRepo examSiteRepo)
        {
            _examSiteRepo = examSiteRepo;
        }

        // GET: ExamSite
        public ActionResult Index()
        {
            var sites = _examSiteRepo.getAll();
            var viewModelSites = sites.Select(s => new ExamSiteViewModel(s));

            return View(viewModelSites);
        }

        // GET: ExamSite/Details/5
        public ActionResult Details(int id)
        {
            var site = _examSiteRepo.GetExamSiteById(id);
            var siteViewModel = new ExamSiteViewModel(site);

            return View(siteViewModel);
        }

        // GET: ExamSite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamSite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var id = collection["Id"];
            var code = collection["Code"];
            var name = collection["Name"];

            try
            {
                var site = new ExamSiteViewModel()
                {
                    Id = int.Parse(id),
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

        // GET: ExamSite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamSite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var siteId = id;
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
            return View();
        }

        // POST: ExamSite/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSite(int id)
        {
            try
            {
                _examSiteRepo.DeleteExamSite(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
