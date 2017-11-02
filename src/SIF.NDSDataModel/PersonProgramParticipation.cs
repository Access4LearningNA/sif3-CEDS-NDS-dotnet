namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonProgramParticipation", Schema = "ODS")]
    public partial class PersonProgramParticipation
    {
        public int OrganizationPersonRoleId { get; set; }

        public int? RefParticipationTypeId { get; set; }

        public int? RefProgramExitReasonId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int PersonProgramParticipationId { get; set; }
    }
}
