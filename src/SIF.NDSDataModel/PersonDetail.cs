namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonDetail")]
    public partial class PersonDetail
    {
        public int PersonDetailId { get; set; }

        public int PersonId { get; set; }

        [StringLength(35)]
        public string FirstName { get; set; }

        [StringLength(35)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(35)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string GenerationCode { get; set; }

        [StringLength(30)]
        public string Prefix { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        public int? RefSexId { get; set; }

        public bool? HispanicLatinoEthnicity { get; set; }

        public int? RefUSCitizenshipStatusId { get; set; }

        public int? RefVisaTypeId { get; set; }

        public int? RefStateOfResidenceId { get; set; }

        public int? RefProofOfResidencyTypeId { get; set; }

        public int? RefHighestEducationLevelCompletedId { get; set; }

        public int? RefPersonalInformationVerificationId { get; set; }

        [StringLength(60)]
        public string BirthdateVerification { get; set; }

        public int? RefTribalAffiliationId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual RefSex RefSex { get; set; }

        public virtual RefState RefState { get; set; }
    }
}
