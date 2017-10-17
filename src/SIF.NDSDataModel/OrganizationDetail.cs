namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationDetail")]
    public partial class OrganizationDetail
    {
        public int OrganizationDetailId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        public int? RefOrganizationTypeId { get; set; }

        [StringLength(30)]
        public string ShortName { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RefOrganizationType RefOrganizationType { get; set; }
    }
}
