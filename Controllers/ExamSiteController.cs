using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Controllers
{
    [Route("/examSite")]
    public class ExamSiteController : Controller
    {

        public ExamSiteController()
        {

        }

        // GET: ExamSiteController
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {

            return View();
        }

        // GET: ExamSiteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamSiteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamSiteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamSiteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamSiteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamSiteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamSiteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
