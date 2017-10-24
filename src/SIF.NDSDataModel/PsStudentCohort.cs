namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PsStudentCohort")]
    public partial class PsStudentCohort
    {
        public int OrganizationPersonRoleId { get; set; }

        [StringLength(4)]
        public string CohortGraduationYear { get; set; }
    }
}
