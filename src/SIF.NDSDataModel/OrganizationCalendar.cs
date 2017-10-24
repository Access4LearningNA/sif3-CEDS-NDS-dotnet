namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationCalendar")]
    public partial class OrganizationCalendar
    {
        public int OrganizationCalendarId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(30)]
        public string CalendarCode { get; set; }

        [Required]
        [StringLength(60)]
        public string CalendarDescription { get; set; }

        [StringLength(4)]
        public string CalendarYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationCalendarEvent> OrganizationCalendarEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationCalendarSession> OrganizationCalendarSession { get; set; }
    }
}
