namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationSpecialEducation", Schema = "ODS")]
    public partial class ProgramParticipationSpecialEducation
    {
        public int PersonProgramParticipationId { get; set; }

        public bool? AwaitingInitialIDEAEvaluationStatus { get; set; }

        public int? RefIDEAEducationalEnvironmentECId { get; set; }

        public int? RefIDEAEdEnvironmentSchoolAgeId { get; set; }

        public decimal? SpecialEducationFTE { get; set; }

        public int? RefSpecialEducationExitReasonId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SpecialEducationServicesExitDate { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int ProgramParticipationSpecialEducationId { get; set; }
    }
}
