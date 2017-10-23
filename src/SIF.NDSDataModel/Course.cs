namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseSections = new HashSet<CourseSection>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationId { get; set; }

        [StringLength(60)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SubjectAbbreviation { get; set; }

        [StringLength(50)]
        public string SCEDSequenceOfCourse { get; set; }

        public int? InstructionalMinutes { get; set; }

        public int? RefCourseLevelCharacteristicsId { get; set; }

        public int? RefCourseCreditUnitId { get; set; }

        public decimal? CreditValue { get; set; }

        public int? RefInstructionLanguage { get; set; }

        [StringLength(300)]
        public string CertificationDescription { get; set; }

        public int? RefCourseApplicableEducationLevelId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseSection> CourseSections { get; set; }

        public virtual CteCourse CteCourse { get; set; }
    }
}
