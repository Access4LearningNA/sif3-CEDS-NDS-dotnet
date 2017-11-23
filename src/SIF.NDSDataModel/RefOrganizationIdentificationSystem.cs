namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RefOrganizationIdentificationSystem", Schema = "ODS")]
    public partial class RefOrganizationIdentificationSystem
    {
        public int RefOrganizationIdentificationSystemId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(4000)]
        public string Definition { get; set; }

        public int? RefJurisdictionId { get; set; }

        public int? RefOrganizationIdentifierTypeId { get; set; }

        public decimal? SortOrder { get; set; }
    }
}
