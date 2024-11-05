using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeClass
    {
        public AcmeClass()
        {
            AcmeClassRooms = new HashSet<AcmeClassRoom>();
            AcmeStudents = new HashSet<AcmeStudent>();
        }

        public int AclassId { get; set; }
        public string? ClassName { get; set; }
        public DateTime? YearGroup { get; set; }
        public DateTime? GraduationDate { get; set; }
        public int? FkAteacherId { get; set; }

        public virtual ICollection<AcmeClassRoom> AcmeClassRooms { get; set; }
        public virtual ICollection<AcmeStudent> AcmeStudents { get; set; }
    }
}
