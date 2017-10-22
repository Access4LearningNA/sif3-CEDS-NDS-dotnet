namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12StudentCourseSection")]
    public partial class K12StudentCourseSection
    {
        public int OrganizationPersonRoleId { get; set; }

        public int? RefCourseRepeatCodeId { get; set; }

        public int? RefCourseSectionEnrollmentStatusTypeId { get; set; }

        public int? RefCourseSectionEntryTypeId { get; set; }

        public int? RefCourseSectionExitTypeId { get; set; }

        public int? RefExitOrWithdrawalStatusId { get; set; }

        public int? RefGradeLevelWhenCourseTakenId { get; set; }

        [StringLength(15)]
        public string GradeEarned { get; set; }

        [StringLength(100)]
        public string GradeValueQualifier { get; set; }

        public decimal? NumberOfCreditsAttempted { get; set; }

        public int? RefCreditTypeEarnedId { get; set; }

        public int? RefAdditionalCreditTypeId { get; set; }

        public int? RefPreAndPostTestIndicatorId { get; set; }

        public int? RefProgressLevelId { get; set; }

        public int? RefCourseGpaApplicabilityId { get; set; }

        public decimal? NumberOfCreditsEarned { get; set; }

        public bool? TuitionFunded { get; set; }
    }
}
