using Exam_Management.Models.RequestModels;
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
    [Route("/ExamSite")]
    public class ExamSiteController : Controller
    {
        public IExamSessionRepo _ExamSessionRepo;
        public ExamSiteController(IExamSessionRepo examSessionRepo)
        {
            _ExamSessionRepo = examSessionRepo;
        }

        // GET: ExamSiteController
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var examSessions = _ExamSessionRepo.GetAll()
                .Select(s => new ExamSessionViewModel(s));

            return View(examSessions);
        }

        // GET: ExamSiteController/Details/5
        public ActionResult Details(int id)
        {
            var dbSession = _ExamSessionRepo.GetExamSessionById(id);
            var session = new ExamSessionViewModel(dbSession);

            return View(session);
        }

        [HttpGet]
        public ActionResult CreateSession()
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
                var id = collection["Id"];
                var sessionName = collection["SessionName"];
                var description = collection["Description"];
                var startDate = collection["StartDate"];
                var endDate = collection["EndDate"];
                var examSiteId = collection["examSiteId"];

                var examSession = new ExamSessionRequestModel()
                {
                    Id = int.Parse(id),
                    SessionName = sessionName,
                    Description = description,
                    StartDate = DateTime.Parse(startDate),
                    EndDate = DateTime.Parse(endDate),
                    ExamSiteId = int.Parse(examSiteId)
                };

                _ExamSessionRepo.AddExamSession(examSession);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateSession", new { Error = "Invalid Input" });
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
            var sessionName = collection["SessionName"];
            var description = collection["Description"];
            var startDate = collection["StartDate"];
            var endDate = collection["EndDate"];
            var examSiteId = collection["examSiteId"];

            var examSession = new ExamSessionRequestModel()
            {
                Id = id,
                SessionName = sessionName,
                Description = description,
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate),
                ExamSiteId = int.Parse(examSiteId)
            };

            try
            {
                _ExamSessionRepo.Update(examSession);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamSiteController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var session = _ExamSessionRepo.GetExamSessionById(id);
            return View(session);
        }

        // POST: ExamSiteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Delete/Post/{id}")]
        public ActionResult Delete(ExamSessionRequestModel request)
        {
            _ExamSessionRepo.DeleteExamSession((int)request.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
