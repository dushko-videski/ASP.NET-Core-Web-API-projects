using System.Collections.Generic;

namespace SimplifiedCollageSystem.DomainModels
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FullName { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

    }
}
