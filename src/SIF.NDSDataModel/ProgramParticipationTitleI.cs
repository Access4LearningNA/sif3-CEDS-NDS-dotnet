namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationTitleI", Schema = "ODS")]
    public partial class ProgramParticipationTitleI
    {
        public int PersonProgramParticipationId { get; set; }

        public int? RefTitleIIndicatorId { get; set; }
    }
}
