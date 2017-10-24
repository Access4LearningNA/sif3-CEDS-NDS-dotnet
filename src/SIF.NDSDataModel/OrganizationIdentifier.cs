namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationIdentifier")]
    public partial class OrganizationIdentifier
    {
        public int OrganizationIdentifierId { get; set; }

        [StringLength(40)]
        public string Identifier { get; set; }

        public int? RefOrganizationIdentificationSystemId { get; set; }

        public int OrganizationId { get; set; }

        public int? RefOrganizationIdentifierTypeId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RefOrganizationIdentifierType RefOrganizationIdentifierType { get; set; }
    }
}
