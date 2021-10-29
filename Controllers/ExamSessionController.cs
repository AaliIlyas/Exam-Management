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
    [Route("/ExamSession")]
    public class ExamSessionController : Controller
    {
        public IExamSessionRepo _ExamSessionRepo;
        public ExamSessionController(IExamSessionRepo examSessionRepo)
        {
            _ExamSessionRepo = examSessionRepo;
        }

        // GET: ExamSiteController
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var examSessions = _ExamSessionRepo.GetAll()
                .Select(s => new ExamSessionViewModel(s, true));

            return View(examSessions);
        }

        // GET: ExamSiteController/Details/5
        [Route("Details")]
        public ActionResult Details(int id)
        {
            var dbSession = _ExamSessionRepo.GetExamSessionById(id);
            var session = new ExamSessionViewModel(dbSession, true);

            return View(session);
        }

        [Route("Create")]
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
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            var dbModel = _ExamSessionRepo.GetExamSessionById(id);
            var session = new ExamSessionViewModel(dbModel, true);

            return View(session);
        }

        // POST: ExamSiteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSession(ExamSessionViewModel session)
        {
            _ExamSessionRepo.DeleteExamSession(session.SessionId);
            return RedirectToAction(nameof(Index));
        }
    }
}
