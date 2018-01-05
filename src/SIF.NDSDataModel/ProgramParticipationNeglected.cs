namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationNeglected", Schema = "ODS")]
    public partial class ProgramParticipationNeglected
    {
        public int PersonProgramParticipationId { get; set; }

        public int? RefNeglectedProgramTypeId { get; set; }

        public bool? AchievementIndicator { get; set; }

        public bool? OutcomeIndicator { get; set; }

        public bool? ObtainedEmployment { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int ProgramParticipationNeglectedId { get; set; }
    }
}
