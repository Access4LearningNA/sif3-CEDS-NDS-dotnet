namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.K12School")]
    public partial class K12School
    {
        public int OrganizationId { get; set; }

        public int? RefSchoolTypeId { get; set; }

        public int? RefSchoolLevelId { get; set; }

        public int? RefAdministrativeFundingControlId { get; set; }

        public bool? CharterSchoolIndicator { get; set; }

        public int? RefCharterSchoolTypeId { get; set; }

        public int? RefIncreasedLearningTimeTypeId { get; set; }

        public int? RefStatePovertyDesignationId { get; set; }

        [StringLength(9)]
        public string CharterSchoolApprovalYear { get; set; }

        public int? RefCharterSchoolApprovalAgencyTypeId { get; set; }

        [StringLength(300)]
        public string AccreditationAgencyName { get; set; }

        public bool? CharterSchoolOpenEnrollmentIndicator { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CharterSchoolContractApprovalDate { get; set; }

        [StringLength(30)]
        public string CharterSchoolContractIdNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CharterSchoolContractRenewalDate { get; set; }

        public int? RefCharterSchoolManagementOrganizationTypeId { get; set; }

        public int K12SchoolId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RefSchoolLevel RefSchoolLevel { get; set; }

        public virtual RefSchoolType RefSchoolType { get; set; }
    }
}
