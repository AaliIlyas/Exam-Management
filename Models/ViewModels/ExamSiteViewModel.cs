using Exam_Management.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Models.ViewModels
{
    public class ExamSiteViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ExamSiteViewModel(ExamSite examSite)
        {
            Id = examSite.Id;
            Code = examSite.Code;
            Name = examSite.Name; 
        }
    }
}
