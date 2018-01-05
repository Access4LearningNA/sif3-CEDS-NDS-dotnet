namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationMigrant", Schema = "ODS")]
    public partial class ProgramParticipationMigrant
    {
        public int PersonProgramParticipationId { get; set; }

        public int? RefMepEnrollmentTypeId { get; set; }

        public int? RefMepProjectBasedId { get; set; }

        public int? RefMepServiceTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MepEligibilityExpirationDate { get; set; }

        public bool? ContinuationOfServicesStatus { get; set; }

        public int? RefContinuationOfServicesReasonId { get; set; }

        [StringLength(60)]
        public string BirthdateVerification { get; set; }

        public bool? ImmunizationRecordFlag { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MigrantStudentQualifyingArrivalDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastQualifyingMoveDate { get; set; }

        [StringLength(30)]
        public string QualifyingMoveFromCity { get; set; }

        public int? RefQualifyingMoveFromStateId { get; set; }

        public int? RefQualifyingMoveFromCountryId { get; set; }

        public int? DesignatedGraduationSchoolId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int ProgramParticipationMigrantId { get; set; }
    }
}
