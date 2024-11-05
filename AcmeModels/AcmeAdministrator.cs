using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeAdministrator
    {
        public AcmeAdministrator()
        {
            AcmeClassRooms = new HashSet<AcmeClassRoom>();
        }

        public int AadminId { get; set; }
        public string? AadminMail { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndofService { get; set; }
        public int? CompetenceLevel { get; set; }
        public decimal? Salary { get; set; }
        public int? FkApid { get; set; }

        public virtual AcmePerson? FkAp { get; set; }
        public virtual ICollection<AcmeClassRoom> AcmeClassRooms { get; set; }
    }
}
