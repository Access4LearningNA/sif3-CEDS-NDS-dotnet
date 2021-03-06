namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationCalendar", Schema = "ODS")]
    public partial class OrganizationCalendar
    {
        public OrganizationCalendar()
        {
            OrganizationCalendarSession = new HashSet<OrganizationCalendarSession>();
            OrganizationCalendarEvent = new HashSet<OrganizationCalendarEvent>();

        }

        public int OrganizationCalendarId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(30)]
        public string CalendarCode { get; set; }

        [Required]
        [StringLength(60)]
        public string CalendarDescription { get; set; }

        [StringLength(4)]
        public string CalendarYear { get; set; }

        [StringLength(36)]
        public string refId { get; set; }

        public virtual ICollection<OrganizationCalendarSession> OrganizationCalendarSession { get; set; }
        public virtual ICollection<OrganizationCalendarEvent> OrganizationCalendarEvent { get; set; }
    }
}
