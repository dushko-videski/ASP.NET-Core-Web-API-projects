using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplifiedCollageSystem.Models
{
    public class StudentModel
    {

        public int StudentNumber { get; set; }

        public string FullName { get; set; }


        [Phone]
        [RegularExpression(@"((00)?\+?[389]{3})?[\/\-\s*\.]?(((\(0\))|0)?\s*7\d{1})[\/\-\s*\.\,]?([\d]{3})[\/\-\s*\.\,]?([\d]{3})")]
        public string MobilePhone { get; set; }


        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string EmailAddress { get; set; }


        [MinLength(2, ErrorMessage = "Select at least 2 subjects!")]
        public IEnumerable<SubjectModel> Subjects { get; set; }



    }
}
