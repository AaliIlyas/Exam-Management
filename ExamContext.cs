using Exam_Management.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Exam_Management
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options) {}

        public DbSet<ExamSession> ExamSession { get; set; }
        public DbSet<ExamSite> ExamSite { get; set; }
    }
}
