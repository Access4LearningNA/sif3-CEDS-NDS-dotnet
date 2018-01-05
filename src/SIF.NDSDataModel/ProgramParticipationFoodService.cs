namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramParticipationFoodService", Schema = "ODS")]
    public partial class ProgramParticipationFoodService
    {
        public int ProgramParticipationFoodServiceId { get; set; }

        public int PersonProgramParticipationId { get; set; }

        public int RefSchoolFoodServiceProgramId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }
    }
}
