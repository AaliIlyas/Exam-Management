using Exam_Management.Models.Database;
using Exam_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Repositories
{
    public interface IExamSiteRepo
    {
        IEnumerable<ExamSite> getAll();
        void AddExamSite(ExamSiteViewModel examSite); //ExamSiteRequestModel
        ExamSite GetExamSiteById(int id);
        void UpdateExamSite(ExamSiteViewModel examSite);
        void DeleteExamSite(int id);
    }

    public class ExamSiteRepo : IExamSiteRepo
    {
        public ExamContext _context;

        public ExamSiteRepo(ExamContext examContext)
        {
            _context = examContext;
        }

        public IEnumerable<ExamSite> getAll()
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
            var examSiteDbModel = new ExamSite()
            {
                Code = examSite.Code,
                Name = examSite.Name,
            };

            _context.ExamSite.Update(examSiteDbModel);
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
