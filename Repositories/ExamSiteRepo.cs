using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Repositories
{
    public class ExamSiteRepo
    {
        public ExamContext _context;
        public ExamSiteRepo(ExamContext examContext)
        {
            _context = examContext;
        }


    }
}
