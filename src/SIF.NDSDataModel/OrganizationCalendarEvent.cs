namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationCalendarEvent")]
    public partial class OrganizationCalendarEvent
    {
        public int OrganizationCalendarEventId { get; set; }

        public int OrganizationCalendarId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime EventDate { get; set; }

        public int? RefCalendarEventType { get; set; }
    }
}
