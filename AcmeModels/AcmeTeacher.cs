using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeTeacher
    {
        public AcmeTeacher()
        {
            AcmeCourseGrades = new HashSet<AcmeCourseGrade>();
            AcmeCourses = new HashSet<AcmeCourse>();
        }

        public int AteacherId { get; set; }
        public string? AteacherMail { get; set; }
        public DateTime? HireDate { get; set; }
        public int? CompetenceLevel { get; set; }
        public decimal? Salary { get; set; }
        public int? FkApid { get; set; }

        public virtual AcmePerson? FkAp { get; set; }
        public virtual ICollection<AcmeCourseGrade> AcmeCourseGrades { get; set; }
        public virtual ICollection<AcmeCourse> AcmeCourses { get; set; }
    }
}
