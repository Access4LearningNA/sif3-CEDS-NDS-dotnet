namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.RoleAttendanceEvent")]
    public partial class RoleAttendanceEvent
    {
        public int RoleAttendanceEventId { get; set; }

        public int OrganizationPersonRoleId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? RefAttendanceEventTypeId { get; set; }

        public int? RefAttendanceStatusId { get; set; }

        public int? RefAbsentAttendanceCategoryId { get; set; }

        public int? RefPresentAttendanceCategoryId { get; set; }

        public int? RefLeaveEventTypeId { get; set; }
    }
}
