using Exam_Management.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Models.Database
{
    public class ExamSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set; }
        [Required]
        public string SessionName { get; set; }
        public string Description { get; set; }
        [RequireWhenEndExists]
        public DateTime? StartDate { get; set; }
        [RequireWhenStartExists]
        public DateTime? EndDate { get; set; }
        [Required]
        public ExamSite ExamSite { get; set; }
    }
}

public class RequireWhenStartExistsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var exam = (ExamSession)validationContext.ObjectInstance;
        if (exam.StartDate != null)
            return ValidationResult.Success;

        var date = value;
        return date == null
            ? new ValidationResult("Value is required.")
            : ValidationResult.Success;
    }
}

public class RequireWhenEndExistsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var exam = (ExamSession)validationContext.ObjectInstance;
        if (exam.EndDate != null)
            return ValidationResult.Success;

        var date = value;
        return date == null
            ? new ValidationResult("Value is required.")
            : ValidationResult.Success;
    }
}