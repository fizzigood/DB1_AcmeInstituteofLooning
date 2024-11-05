using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeCourseGrade
    {
        public int AgradeId { get; set; }
        public DateTime? DateSet { get; set; }
        public int? GradeScore { get; set; }
        public int? FkAcourseId { get; set; }
        public int? FkAstudentId { get; set; }
        public int? FkAteacherId { get; set; }

        public virtual AcmeCourse? FkAcourse { get; set; }
        public virtual AcmeStudent? FkAstudent { get; set; }
        public virtual AcmeTeacher? FkAteacher { get; set; }
    }
}
