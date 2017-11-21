namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("K12StudentDiscipline", Schema = "ODS")]
    public partial class K12StudentDiscipline
    {
        public int K12StudentDisciplineId { get; set; }

        public int OrganizationPersonRoleId { get; set; }

        public int? RefDisciplineReasonId { get; set; }

        public int? RefDisciplinaryActionTakenId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisciplinaryActionStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisciplinaryActionEndDate { get; set; }

        public decimal? DurationOfDisciplinaryAction { get; set; }

        public int? RefDisciplineLengthDifferenceReasonId { get; set; }

        public bool? FullYearExpulsion { get; set; }

        public bool? ShortenedExpulsion { get; set; }

        public bool? EducationalServicesAfterRemoval { get; set; }

        public int? RefIdeaInterimRemovalId { get; set; }

        public int? RefIdeaInterimRemovalReasonId { get; set; }

        public bool? RelatedToZeroTolerancePolicy { get; set; }

        public int? IncidentId { get; set; }

        public bool? IEPPlacementMeetingIndicator { get; set; }

        public int? RefDisciplineMethodFirearmsId { get; set; }

        public int? RefDisciplineMethodOfCwdId { get; set; }

        public int? RefIDEADisciplineMethodFirearmId { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
