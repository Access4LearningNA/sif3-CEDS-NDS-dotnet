namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location", Schema = "ODS")]
    public partial class Location
    {
        public Location()
        {
            LocationAddress = new HashSet<LocationAddress>();
        }
        [Key]
       
        public int LocationId { get; set; }
        public virtual ICollection<LocationAddress> LocationAddress { get; set; }
    }
}
