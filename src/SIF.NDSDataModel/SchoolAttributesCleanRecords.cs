namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SIF.SchoolAttributesCleanRecords")]
    public partial class SchoolAttributesCleanRecords
    {
        [Key]
        public int CleanRecordId { get; set; }

        public int SchoolAttributesId { get; set; }

        public long? BlobId { get; set; }

        [StringLength(36)]
        public string SchoolRefId { get; set; }

        public string ErrorReason { get; set; }

        public string emailAddress { get; set; }

        public string emailTypeCode { get; set; }

        public string externalIdTypeCode { get; set; }

        public string idTypeCode { get; set; }

        public string localIdIdvalue { get; set; }

        public string operationalStatusCode { get; set; }

        public string phoneNumberExtension { get; set; }

        public string phoneNumber { get; set; }

        public string phoneNumberTypeCode { get; set; }

        public string schoolContactAddressRole { get; set; }

        public string schoolContactBirthdate { get; set; }

        public string schoolContactBirthdateverification { get; set; }

        public string schoolContactcountryOfResidencyCode { get; set; }

        public string schoolContactSexus { get; set; }

        public string schoolContactElectronicIdValue { get; set; }

        public string schoolContactEmailaddress { get; set; }

        public string schoolContactEmailTypeCode { get; set; }

        public string schoolContactExternalIdTypeCode { get; set; }

        public string schoolContactExternalIdvalue { get; set; }

        public string schoolContactLocalIdTypeCode { get; set; }

        public string schoolContactLocalIdValue { get; set; }

        public string schoolContactFamilyname { get; set; }

        public string schoolContactFullname { get; set; }

        public string schoolContactGivenname { get; set; }

        public string schoolContactMiddlename { get; set; }

        public string schoolContactPreferredfamilyname { get; set; }

        public string schoolContactPreferredgivenname { get; set; }

        public string schoolContactPrefix { get; set; }

        public string schoolContactSuffix { get; set; }

        public string schoolContactOtherNameFamilyname { get; set; }

        public string schoolContactOtherNameFullname { get; set; }

        public string schoolContactOtherNameGivenname { get; set; }

        public string schoolContactOtherNameMiddlename { get; set; }

        public string schoolContactOtherNamePreferredfamilyname { get; set; }

        public string schoolContactOtherNamePreferredgivenname { get; set; }

        public string schoolContactphoneNumberExtension { get; set; }

        public string schoolContactphoneNumber { get; set; }

        public string schoolContactphoneNumberTypeCode { get; set; }

        public string schoolFocus { get; set; }

        public string schoolName { get; set; }

        public string schoolSector { get; set; }

        public string schoolTypeCode { get; set; }

        public string schoolURL { get; set; }

        public byte StatusId { get; set; }

        public int? BatchId { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreateDateTime { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
