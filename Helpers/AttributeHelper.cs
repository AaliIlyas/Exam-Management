using Exam_Management.Models.Database;
using Exam_Management.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Management.Helpers
{
    public class AttributeHelper
    {
        public class RequireWhenStartExistsAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var exam = (ExamSessionRequestModel)validationContext.ObjectInstance;
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
                var exam = (ExamSessionRequestModel)validationContext.ObjectInstance;
                if (exam.EndDate != null)
                    return ValidationResult.Success;

                var date = value;
                return date == null
                    ? new ValidationResult("Value is required.")
                    : ValidationResult.Success;
            }
        }
    }
}
