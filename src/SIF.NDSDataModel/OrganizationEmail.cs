namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationEmail")]
    public partial class OrganizationEmail
    {
        public int OrganizationEmailId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(128)]
        public string ElectronicMailAddress { get; set; }

        public int? RefEmailTypeId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RefEmailType RefEmailType { get; set; }
    }
}
