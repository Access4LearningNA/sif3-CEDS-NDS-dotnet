namespace SIF.NDSDataModel

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationProgramType", Schema = "ODS")]
    public partial class OrganizationProgramType
    {
        public int OrganizationProgramTypeId { get; set; }

        public int OrganizationId { get; set; }

        public int RefProgramTypeId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }
    }
}
