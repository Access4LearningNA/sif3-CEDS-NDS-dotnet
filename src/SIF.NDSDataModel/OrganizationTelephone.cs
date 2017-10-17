namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationTelephone")]
    public partial class OrganizationTelephone
    {
        public int OrganizationTelephoneId { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(24)]
        public string TelephoneNumber { get; set; }

        public bool PrimaryTelephoneNumberIndicator { get; set; }

        public int? RefInstitutionTelephoneTypeId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
