namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationEmail", Schema = "ODS")]
    public partial class OrganizationEmail
    {
        public int OrganizationEmailId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(128)]
        public string ElectronicMailAddress { get; set; }

        public int? RefEmailTypeId { get; set; }

       
    }
}
