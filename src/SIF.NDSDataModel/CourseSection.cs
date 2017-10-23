namespace SIF.NDSDataModel
{
    using SIF.NDSDataModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.CourseSection")]
    public partial class CourseSection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSection()
        {
            CourseSectionLocation = new HashSet<CourseSectionLocation>();
            CourseSectionSchedule = new HashSet<CourseSectionSchedule>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationId { get; set; }

        public decimal? AvailableCarnegieUnitCredit { get; set; }

        public int? RefCourseSectionDeliveryModeId { get; set; }

        public int? RefSingleSexClassStatusId { get; set; }

        public decimal? TimeRequiredForCompletion { get; set; }

        public int CourseId { get; set; }

        public int? RefAdditionalCreditTypeId { get; set; }

        public int? RefInstructionLanguageId { get; set; }

        public bool? VirtualIndicator { get; set; }

        public int? OrganizationCalendarSessionId { get; set; }

        public int? RefCreditTypeEarnedId { get; set; }

        [StringLength(60)]
        public string RelatedLearningStandards { get; set; }

        public int? RefAdvancedPlacementCourseCodeId { get; set; }

        public int? MaximumCapacity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseSectionLocation> CourseSectionLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseSectionSchedule> CourseSectionSchedule { get; set; }
    }
}
