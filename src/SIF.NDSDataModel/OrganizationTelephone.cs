namespace SIF.NDSDataModel
{
   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("OrganizationTelephone", Schema = "ODS")]
    public partial class OrganizationTelephone
    {
        public int OrganizationTelephoneId { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(24)]
        public string TelephoneNumber { get; set; }

        public bool PrimaryTelephoneNumberIndicator { get; set; }

        public int? RefInstitutionTelephoneTypeId { get; set; }

      
    }
}
