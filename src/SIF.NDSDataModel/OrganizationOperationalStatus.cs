namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationOperationalStatus")]
    public partial class OrganizationOperationalStatus
    {
        public int OrganizationOperationalStatusId { get; set; }

        public int OrganizationId { get; set; }

        public int RefOperationalStatusId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OperationalStatusEffectiveDate { get; set; }

        public virtual Organization Organization { get; set; }
    }
}