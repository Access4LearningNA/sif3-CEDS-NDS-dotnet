namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.OrganizationCalendarSession")]
    public partial class OrganizationCalendarSession
    {
        public int OrganizationCalendarSessionId { get; set; }

        [StringLength(7)]
        public string Designator { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? RefSessionTypeId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InstructionalMinutes { get; set; }

        [StringLength(30)]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool? MarkingTermIndicator { get; set; }

        public bool? SchedulingTermIndicator { get; set; }

        public bool? AttendanceTermIndicator { get; set; }

        public int? OrganizationCalendarId { get; set; }

        public int? DaysInSession { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FirstInstructionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastInstructionDate { get; set; }

        public int? MinutesPerDay { get; set; }

        public TimeSpan? SessionStartTime { get; set; }

        public TimeSpan? SessionEndTime { get; set; }
    }
}
