using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Models.ViewModels
{
    public class ResultsViewModel
    {
        public DateTime ExamDate { get; set; }
        public IEnumerable<Learner> Learners { get; set; }
    }

    public class Learner
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string reference { get; set; }
        public List<Assessment> Assessments { get; set; }
    }

    public class Assessment
    {
        public string AssessmentName { get; set; }
        public string reference { get; set; }
        public int Mark { get; set; }
        public Grade Result { get; set; }
    }

    public enum Grade
    {
        FAIL,
        PASS,
        MERIT,
        DISTINCTION
    }
}

