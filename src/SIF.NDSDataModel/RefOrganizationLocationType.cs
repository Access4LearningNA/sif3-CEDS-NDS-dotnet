namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.RefOrganizationLocationType")]
    public partial class RefOrganizationLocationType
    {
        public int RefOrganizationLocationTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(4000)]
        public string Definition { get; set; }

        public int? RefJurisdictionId { get; set; }

        public decimal? SortOrder { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
