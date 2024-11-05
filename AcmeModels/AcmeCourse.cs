using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeCourse
    {
        public AcmeCourse()
        {
            AcmeClassRooms = new HashSet<AcmeClassRoom>();
            AcmeCourseGrades = new HashSet<AcmeCourseGrade>();
        }

        public int AcourseId { get; set; }
        public string? Subject { get; set; }
        public DateTime? CourseStart { get; set; }
        public DateTime? CourseEnd { get; set; }
        public int? FkAteacherId { get; set; }

        public virtual AcmeTeacher? FkAteacher { get; set; }
        public virtual ICollection<AcmeClassRoom> AcmeClassRooms { get; set; }
        public virtual ICollection<AcmeCourseGrade> AcmeCourseGrades { get; set; }
    }
}
