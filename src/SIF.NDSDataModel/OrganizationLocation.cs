namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationLocation", Schema = "ODS")]
    public partial class OrganizationLocation
    {
        public int OrganizationLocationId { get; set; }

        public int OrganizationId { get; set; }

        public int LocationId { get; set; }

        public int? RefOrganizationLocationTypeId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
