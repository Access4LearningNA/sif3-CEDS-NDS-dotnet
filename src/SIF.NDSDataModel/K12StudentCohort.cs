namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12StudentCohort")]
    public partial class K12StudentCohort
    {
        public int OrganizationPersonRoleId { get; set; }

        [StringLength(4)]
        public string CohortYear { get; set; }

        [StringLength(4)]
        public string CohortGraduationYear { get; set; }

        [StringLength(4)]
        public string GraduationRateSurveyCohortYear { get; set; }

        public bool? GraduationRateSurveyIndicator { get; set; }

        [StringLength(30)]
        public string CohortDescription { get; set; }
    }
}
