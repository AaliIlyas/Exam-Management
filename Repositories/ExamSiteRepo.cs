using Exam_Management.Models.Database;
using Exam_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Repositories
{
    public class ExamSiteRepo : IExamSiteRepo
    {
        public ExamContext _context;

        public ExamSiteRepo(ExamContext examContext)
        {
            _context = examContext;
        }

        public IEnumerable<ExamSite> GetAll()
        {
            return _context.ExamSite
                .ToList();
        }
        public void AddExamSite(ExamSiteViewModel examSite)
        {
            var examSiteDbModel = new ExamSite()
            {
                Code = examSite.Code,
                Name = examSite.Name,
            };

            _context.ExamSite.Add(examSiteDbModel);
            _context.SaveChanges();
        }

        public ExamSite GetExamSiteById(int id)
        {
            return _context.ExamSite
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }
        public void UpdateExamSite(ExamSiteViewModel examSite)
        {
            var site = _context.ExamSite.Find(examSite.Id);

            site.Code = examSite.Code;
            site.Name = examSite.Name;

            _context.SaveChanges();
        }

        public void DeleteExamSite(int id)
        {
            var site = GetExamSiteById(id);
            _context.Remove(site);
            _context.SaveChanges();
        }
    }
}
