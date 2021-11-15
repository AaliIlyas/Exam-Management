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
    public class ExamSessionController : Controller
    {
        public IExamSessionRepo _ExamSessionRepo;
        public ExamSessionController(IExamSessionRepo examSessionRepo)
        {
            _ExamSessionRepo = examSessionRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var examSessions = _ExamSessionRepo.GetAll()
                .Select(s => new ExamSessionViewModel(s, true));

            return View(examSessions);
        }

        public ActionResult Details(int id)
        {
            var dbSession = _ExamSessionRepo.GetExamSessionById(id);
            var session = new ExamSessionViewModel(dbSession, true);

            return View(session);
        }

        [HttpGet]
        public ActionResult CreateSession()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExamSessionRequestModel session)
        {
            try 
            { 
                _ExamSessionRepo.AddExamSession(session);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateSession", new { Error = "Invalid Input" });
            }
        }

        // POST: ExamSiteController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExamSessionRequestModel collection)
        {
            try
            {
                _ExamSessionRepo.Update(collection);
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
            var dbModel = _ExamSessionRepo.GetExamSessionById(id);
            var session = new ExamSessionViewModel(dbModel, true);

            return View(session);
        }

        // POST: ExamSiteController/Delete/5
        [HttpPost]
        public ActionResult DeleteSession(ExamSessionViewModel session)
        {
            _ExamSessionRepo.DeleteExamSession(session.SessionId);
            return RedirectToAction(nameof(Index));
        }
    }
}
