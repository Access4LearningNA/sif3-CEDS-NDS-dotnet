namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Program", Schema = "ODS")]
    public partial class Program
    {
        [Key]
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        public decimal? CreditsRequired { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
