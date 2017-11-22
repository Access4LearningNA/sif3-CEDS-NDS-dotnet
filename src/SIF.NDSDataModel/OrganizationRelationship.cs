namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationRelationship", Schema = "ODS")]
    public partial class OrganizationRelationship
    {
        public int OrganizationRelationshipId { get; set; }

        public int Parent_OrganizationId { get; set; }

        public int OrganizationId { get; set; }

        public int? RefOrganizationRelationshipId { get; set; }
    }
}
