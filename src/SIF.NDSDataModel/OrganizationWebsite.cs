namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationWebsite", Schema = "ODS")]
    public partial class OrganizationWebsite
    {
      [Key]
      [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        [StringLength(300)]
        public string Website { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
