namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12StudentEnrollment")]
    public partial class K12StudentEnrollment
    {
        public int OrganizationPersonRoleId { get; set; }

        public int? RefEntryGradeLevelId { get; set; }

        public int? RefPublicSchoolResidence { get; set; }

        public int? RefEnrollmentStatusId { get; set; }

        public int? RefEntryType { get; set; }

        public int? RefExitGradeLevel { get; set; }

        public int? RefExitOrWithdrawalStatusId { get; set; }

        public int? RefExitOrWithdrawalTypeId { get; set; }

        public bool? DisplacedStudentStatus { get; set; }

        public int? RefEndOfTermStatusId { get; set; }

        public int? RefPromotionReasonId { get; set; }

        public int? RefNonPromotionReasonId { get; set; }

        public int? RefFoodServiceEligibilityId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FirstEntryDateIntoUSSchool { get; set; }

        public int? RefDirectoryInformationBlockStatusId { get; set; }

        public bool? NSLPDirectCertificationIndicator { get; set; }

        public int K12StudentEnrollmentId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }
    }
}
