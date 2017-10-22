namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12StaffAssignment")]
    public partial class K12StaffAssignment
    {
        public int OrganizationPersonRoleId { get; set; }

        public int? RefK12StaffClassificationId { get; set; }

        public int? RefProfessionalEducationJobClassificationId { get; set; }

        public int? RefTeachingAssignmentRoleId { get; set; }

        public bool? PrimaryAssignment { get; set; }

        public bool? TeacherOfRecord { get; set; }

        public int? RefClassroomPositionTypeId { get; set; }

        public decimal? FullTimeEquivalency { get; set; }

        public decimal? ContributionPercentage { get; set; }

        public bool? ItinerantTeacher { get; set; }

        public bool? HighlyQualifiedTeacherIndicator { get; set; }

        public bool? SpecialEducationTeacher { get; set; }

        public int? RefSpecialEducationStaffCategoryId { get; set; }

        public bool? SpecialEducationRelatedServicesPersonnel { get; set; }

        public bool? SpecialEducationParaprofessional { get; set; }

        public int? RefSpecialEducationAgeGroupTaughtId { get; set; }

        public int? RefMepStaffCategoryId { get; set; }

        public int? RefTitleIProgramStaffCategoryId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int K12StaffAssignmentId { get; set; }
    }
}
