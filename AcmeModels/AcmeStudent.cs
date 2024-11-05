using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeStudent
    {
        public AcmeStudent()
        {
            AcmeCourseGrades = new HashSet<AcmeCourseGrade>();
        }

        public int AstudentId { get; set; }
        public string? AstudentMail { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public int? FkApid { get; set; }
        public int? FkAclassId { get; set; }

        public virtual AcmeClass? FkAclass { get; set; }
        public virtual AcmePerson? FkAp { get; set; }
        public virtual ICollection<AcmeCourseGrade> AcmeCourseGrades { get; set; }
    }
}
