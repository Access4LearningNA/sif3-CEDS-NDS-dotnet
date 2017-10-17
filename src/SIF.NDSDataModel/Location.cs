namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.Location")]
    public partial class Location
    {
        public int LocationId { get; set; }

        public virtual LocationAddress LocationAddress { get; set; }
    }
}
