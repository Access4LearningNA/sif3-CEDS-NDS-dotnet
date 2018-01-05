namespace SIF.NDSDataModel
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("ProgramParticipationTitleIIILep", Schema = "ODS")]
    public partial class ProgramParticipationTitleIIILep
    {
        public int? RefTitleIIIAccountabilityId { get; set; }

        public int? RefTitleIIILanguageInstructionProgramTypeId { get; set; }

        public int PersonProgramParticipationId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int ProgramParticipationTitleIiiLepId { get; set; }
    }
}
