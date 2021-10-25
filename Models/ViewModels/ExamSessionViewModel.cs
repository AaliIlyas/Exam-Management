using Exam_Management.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Models.ViewModels
{
    public class ExamSessionViewModel
    {
        public int SessionId { get; set; }

        public string SessionName { get; set; }
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ExamSiteViewModel? ExamSite { get; set; }

        public ExamSessionViewModel(ExamSession examSession, bool loadDependencies = false)
        {
            SessionId = examSession.SessionId;
            SessionName = examSession.SessionName;
            Description = examSession.Description;
            StartDate = examSession.StartDate;
            EndDate = examSession.EndDate;
            
            if (loadDependencies)
            {
                ExamSite = new ExamSiteViewModel(examSession.ExamSite);
            }
        }
    }
}
