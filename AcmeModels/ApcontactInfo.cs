using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class ApcontactInfo
    {
        public ApcontactInfo()
        {
            ContactIces = new HashSet<ContactIce>();
        }

        public int AcontactId { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AltTel { get; set; }
        public int? FkApid { get; set; }

        public virtual AcmePerson? FkAp { get; set; }
        public virtual ICollection<ContactIce> ContactIces { get; set; }
    }
}
