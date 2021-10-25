using Exam_Management.Models.Database;
using Exam_Management.Models.RequestModels;
using System.Collections.Generic;

namespace Exam_Management.Repositories
{
    public interface IExamSessionRepo
    {
        void AddExamSession(ExamSessionRequestModel examSession);
        void DeleteExamSession(int id);
        IEnumerable<ExamSession> GetAll();
        ExamSession GetExamSessionById(int id);
        IEnumerable<ExamSession> Search();
        void Update(ExamSessionRequestModel examSession);
    }
}