using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmePerson
    {
        public AcmePerson()
        {
            AcmeAdministrators = new HashSet<AcmeAdministrator>();
            AcmeStudents = new HashSet<AcmeStudent>();
            AcmeTeachers = new HashSet<AcmeTeacher>();
            ApcontactInfos = new HashSet<ApcontactInfo>();
        }

        public int Apid { get; set; }
        public string? Concern { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? FkAdeptId { get; set; }

        public virtual AcmeDept? FkAdept { get; set; }
        public virtual ICollection<AcmeAdministrator> AcmeAdministrators { get; set; }
        public virtual ICollection<AcmeStudent> AcmeStudents { get; set; }
        public virtual ICollection<AcmeTeacher> AcmeTeachers { get; set; }
        public virtual ICollection<ApcontactInfo> ApcontactInfos { get; set; }
    }
}
