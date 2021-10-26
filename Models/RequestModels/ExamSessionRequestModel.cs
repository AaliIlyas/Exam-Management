using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Exam_Management.Helpers.AttributeHelper;

namespace Exam_Management.Models.RequestModels
{
    public class ExamSessionRequestModel
    {
        public int? Id { get; set; }
        public string SessionName { get; set; }
        public string Description { get; set; }
        [RequireWhenEndExists]
        public DateTime? StartDate { get; set; }
        [RequireWhenStartExists]
        public DateTime? EndDate { get; set; }
        public int? ExamSiteId { get; set; }
    }
}
