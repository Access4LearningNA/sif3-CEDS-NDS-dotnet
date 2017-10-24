namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PsStudentSection")]
    public partial class PsStudentSection
    {
        [Key]
        public int OrganizationPersonRoleId { get; set; }

        [StringLength(80)]
        public string CourseOverrideSchool { get; set; }

        public bool? DegreeApplicability { get; set; }

        [StringLength(15)]
        public string AcademicGrade { get; set; }

        public decimal? NumberOfCreditsEarned { get; set; }

        public decimal? QualityPointsEarned { get; set; }

        public int? RefCourseRepeatCodeId { get; set; }

        public int? RefCourseAcademicGradeStatusCodeId { get; set; }
    }
}
