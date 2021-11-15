using System;
using Exam_Management.Helpers;


namespace Exam_Management.Models.RequestModels
{
    public class ExamSessionRequestModel
    {
        public int? Id { get; set; }
        public string SessionName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ExamSiteId { get; set; }
    }
}