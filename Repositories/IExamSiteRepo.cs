using Exam_Management.Models.Database;
using Exam_Management.Models.ViewModels;
using System.Collections.Generic;

namespace Exam_Management.Repositories
{
    public interface IExamSiteRepo
    {
        void AddExamSite(ExamSiteViewModel examSite);
        void DeleteExamSite(int id);
        IEnumerable<ExamSite> getAll();
        ExamSite GetExamSiteById(int id);
        void UpdateExamSite(ExamSiteViewModel examSite);
    }
}