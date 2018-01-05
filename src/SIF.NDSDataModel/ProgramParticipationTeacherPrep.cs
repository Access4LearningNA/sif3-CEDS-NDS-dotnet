namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationTeacherPrep", Schema = "ODS")]
    public partial class ProgramParticipationTeacherPrep
    {
        public int? RefTeacherPrepEnrollmentStatusId { get; set; }

        public int? RefTeacherPrepCompleterStatusId { get; set; }

        public int? RefSupervisedClinicalExperienceId { get; set; }

        public int? ClinicalExperienceClockHours { get; set; }

        public int? RefTeachingCredentialBasisId { get; set; }

        public int? RefTeachingCredentialTypeId { get; set; }

        public int? RefCriticalTeacherShortageCandidateId { get; set; }

        public int? RefAltRouteToCertificationOrLicensureId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int PersonProgramParticipationId { get; set; }

        public int ProgramParticipationTeacherPrepId { get; set; }
    }
}
