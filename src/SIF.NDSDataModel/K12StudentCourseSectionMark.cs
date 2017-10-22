namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12StudentCourseSectionMark")]
    public partial class K12StudentCourseSectionMark
    {
        public int K12StudentCourseSectionMarkId { get; set; }

        public int OrganizationPersonRoleId { get; set; }

        [StringLength(30)]
        public string MarkingPeriodName { get; set; }

        public bool? FinalIndicator { get; set; }

        [StringLength(15)]
        public string GradeEarned { get; set; }

        [StringLength(15)]
        public string MidTermMark { get; set; }

        [StringLength(100)]
        public string GradeValueQualifier { get; set; }

        [StringLength(300)]
        public string StudentCourseSectionGradeNarrative { get; set; }
    }
}
