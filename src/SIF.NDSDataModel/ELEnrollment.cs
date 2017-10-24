namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.ELEnrollment")]
    public partial class ELEnrollment
    {
        public int OrganizationPersonRoleId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApplicationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EnrollmentDate { get; set; }

        public int? RefIDEAEnvironmentELId { get; set; }

        public decimal? NumberOfDaysInAttendance { get; set; }

        public int? RefFoodServiceParticipationId { get; set; }

        public int? RefServiceOptionId { get; set; }

        public int? ELClassSectionId { get; set; }

        public int? RefELFederalFundingTypeId { get; set; }
    }
}
