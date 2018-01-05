namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationAE", Schema = "ODS")]
    public partial class ProgramParticipationAE
    {
        public int PersonProgramParticipationId { get; set; }

        public int? RefAeInstructionalProgramTypeId { get; set; }

        public int? RefAePostsecondaryTransitionActionId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PostsecondaryTransitionDate { get; set; }

        public int? RefAeSpecialProgramTypeId { get; set; }

        public int? RefAeFunctioningLevelAtIntakeId { get; set; }

        public int? RefAeFunctioningLevelAtPosttestId { get; set; }

        public int? RefGoalsForAttendingAdultEducationId { get; set; }

        public bool? DisplacedHomemakerIndicator { get; set; }

        public decimal? ProxyContactHours { get; set; }

        public decimal? InstructionalActivityHoursCompleted { get; set; }

        public int? RefCorrectionalEducationFacilityTypeId { get; set; }

        public int? RefWorkbasedLearningOpportunityTypeId { get; set; }

        public int ProgramParticipationAEId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }
    }
}
