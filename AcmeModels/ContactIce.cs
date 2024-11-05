using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class ContactIce
    {
        public int Iceid { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Connection { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AltTel { get; set; }
        public int? FkAcontactId { get; set; }

        public virtual ApcontactInfo? FkAcontact { get; set; }
    }
}
