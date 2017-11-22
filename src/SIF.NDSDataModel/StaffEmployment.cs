namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffEmployment", Schema = "ODS")]
    public partial class StaffEmployment
    {
        public int StaffEmploymentId { get; set; }

        public int OrganizationPersonRoleId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }

        [StringLength(45)]
        public string PositionTitle { get; set; }

        public int? RefEmploymentSeparationTypeId { get; set; }

        public int? RefEmploymentSeparationReasonId { get; set; }

        [StringLength(200)]
        public string UnionMembershipName { get; set; }

        public int? WeeksEmployedPerYear { get; set; }
    }
}
