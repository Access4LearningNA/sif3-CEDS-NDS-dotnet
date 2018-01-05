namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationCte", Schema = "ODS")]
    public partial class ProgramParticipationCte
    {
        public int PersonProgramParticipationId { get; set; }

        public bool? CteParticipant { get; set; }

        public bool? CteConcentrator { get; set; }

        public bool? CteCompleter { get; set; }

        public bool? SingleParentOrSinglePregnantWoman { get; set; }

        public bool? DisplacedHomemakerIndicator { get; set; }

        public bool? CteNonTraditionalCompletion { get; set; }

        public int? RefNonTraditionalGenderStatusId { get; set; }

        public int? RefWorkbasedLearningOpportunityTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CareerPathwaysProgramParticipationExitDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CareerPathwaysProgramParticipationStartDate { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int ProgramParticipationCteId { get; set; }
    }
}
