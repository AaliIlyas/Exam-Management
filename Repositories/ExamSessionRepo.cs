﻿using Exam_Management.Models.Database;
using Exam_Management.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Repositories
{
    public class ExamSessionRepo : IExamSessionRepo
    {
        public ExamContext _context;

        public ExamSessionRepo(ExamContext examContext)
        {
            _context = examContext;
        }

        public void AddExamSession(ExamSessionRequestModel examSession)
        {
            var examSite = _context.ExamSite
                .Where(e => e.Id == examSession.ExamSiteId)
                .SingleOrDefault();

            var newExamSession = new ExamSession()
            {
                SessionName = examSession.SessionName,
                Description = examSession.Description,
                StartDate = examSession.StartDate,
                EndDate = examSession.EndDate,
                ExamSite = examSite
            };

            _context.ExamSession.Add(newExamSession);
            _context.SaveChanges();
        }

        public void DeleteExamSession(int id)
        {
            var session = _context.ExamSession
                .Where(s => s.SessionId == id)
                .SingleOrDefault();

            _context.ExamSession.Remove(session);
            _context.SaveChanges();
        }

        public IEnumerable<ExamSession> GetAll()
        {
            return _context.ExamSession
                .OrderBy(s => s.SessionName)
                .ToList();
        }

        public ExamSession GetExamSessionById(int id)
        {
            return _context.ExamSession
                .Where(s => s.SessionId == id)
                .FirstOrDefault();
        }

        public IEnumerable<ExamSession> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(ExamSessionRequestModel examSession)
        {
            var examSite = _context.ExamSite
                .Where(e => e.Id == examSession.ExamSiteId)
                .SingleOrDefault();

            var session = _context.ExamSession.Find(examSession.Id);

            session.SessionName = examSession.SessionName;
            session.Description = examSession.Description;
            session.StartDate = examSession.StartDate;
            session.EndDate = examSession.EndDate;
            session.ExamSite = examSite;

            _context.SaveChanges();
        }
    }
}
