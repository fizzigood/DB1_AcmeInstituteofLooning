using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeDept
    {
        public AcmeDept()
        {
            AcmeClassRooms = new HashSet<AcmeClassRoom>();
            AcmePeople = new HashSet<AcmePerson>();
        }

        public int AdeptId { get; set; }
        public string? DeptName { get; set; }
        public decimal? DeptBudget { get; set; }

        public virtual ICollection<AcmeClassRoom> AcmeClassRooms { get; set; }
        public virtual ICollection<AcmePerson> AcmePeople { get; set; }
    }
}
