namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12StudentAcademicRecord")]
    public partial class K12StudentAcademicRecord
    {
        public int OrganizationPersonRoleId { get; set; }

        public decimal? CreditsAttemptedCumulative { get; set; }

        public decimal? CreditsEarnedCumulative { get; set; }

        public decimal? GradePointsEarnedCumulative { get; set; }

        public decimal? GradePointAverageCumulative { get; set; }

        public int? RefGpaWeightedIndicatorId { get; set; }

        [StringLength(7)]
        public string ProjectedGraduationDate { get; set; }

        public int? HighSchoolStudentClassRank { get; set; }

        [StringLength(10)]
        public string ClassRankingDate { get; set; }

        public int? TotalNumberInClass { get; set; }

        [StringLength(7)]
        public string DiplomaOrCredentialAwardDate { get; set; }

        public int? RefHighSchoolDiplomaTypeId { get; set; }

        public int? RefHighSchoolDiplomaDistinctionTypeId { get; set; }

        public int? RefTechnologyLiteracyStatusId { get; set; }

        public int? RefPsEnrollmentActionId { get; set; }

        public int? RefPreAndPostTestIndicatorId { get; set; }

        public int? RefProfessionalTechnicalCredentialTypeId { get; set; }

        public int? RefProgressLevelId { get; set; }
    }
}
