namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.CourseSectionSchedule")]
    public partial class CourseSectionSchedule
    {
        public int CourseSectionScheduleId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(60)]
        public string ClassMeetingDays { get; set; }

        public TimeSpan? ClassBeginningTime { get; set; }

        public TimeSpan? ClassEndingTime { get; set; }

        [StringLength(30)]
        public string ClassPeriod { get; set; }

        [StringLength(40)]
        public string TimeDayIdentifier { get; set; }
    }
}
