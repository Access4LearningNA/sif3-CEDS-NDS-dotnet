namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.RoleAttendance")]
    public partial class RoleAttendance
    {
        public int RoleAttendanceId { get; set; }

        public int OrganizationPersonRoleId { get; set; }

        public decimal? NumberOfDaysInAttendance { get; set; }

        public decimal? NumberOfDaysAbsent { get; set; }

        public decimal? AttendanceRate { get; set; }
    }
}
