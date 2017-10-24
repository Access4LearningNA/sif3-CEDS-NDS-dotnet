namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.CteCourse")]
    public partial class CteCourse
    {
        public int OrganizationId { get; set; }

        public decimal? AvailableCarnegieUnitCredit { get; set; }

        public int? RefAdditionalCreditTypeId { get; set; }

        public int? RefCreditTypeEarnedId { get; set; }

        public bool? HighSchoolCourseRequirement { get; set; }

        public int? RefCourseGpaApplicabilityId { get; set; }

        public bool? CoreAcademicCourse { get; set; }

        public int? RefCurriculumFrameworkTypeId { get; set; }

        public bool? CourseAlignedWithStandards { get; set; }

        [StringLength(5)]
        public string SCEDCourseCode { get; set; }

        public int? RefSCEDCourseLevelId { get; set; }

        public int? RefSCEDCourseSubjectAreaId { get; set; }

        public int? RefCareerClusterId { get; set; }

        [StringLength(60)]
        public string CourseDepartmentName { get; set; }
    }
}
