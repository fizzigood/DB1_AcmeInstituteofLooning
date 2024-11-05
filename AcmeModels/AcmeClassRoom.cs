using System;
using System.Collections.Generic;

namespace DB1_AcmeInstituteofLooning.AcmeModels
{
    public partial class AcmeClassRoom
    {
        public int AcroomId { get; set; }
        public int? FkAdeptIdlocation { get; set; }
        public int? FkAadminId { get; set; }
        public int? FkAcourseId { get; set; }
        public int? FkAclassId { get; set; }

        public virtual AcmeAdministrator? FkAadmin { get; set; }
        public virtual AcmeClass? FkAclass { get; set; }
        public virtual AcmeCourse? FkAcourse { get; set; }
        public virtual AcmeDept? FkAdeptIdlocationNavigation { get; set; }
    }
}
