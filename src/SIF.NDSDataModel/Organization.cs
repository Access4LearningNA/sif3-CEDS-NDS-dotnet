namespace SIF.NDSDataModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Organization", Schema = "ODS")]
   
    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {

            OrganizationDetail = new HashSet<OrganizationDetail>();
            OrganizationTelephone = new HashSet<OrganizationTelephone>();
            OrganizationEmail = new HashSet<OrganizationEmail>();
            OrganizationOperationalStatus = new HashSet<OrganizationOperationalStatus>();
            OrganizationIdentifier = new HashSet<OrganizationIdentifier>();
            OrganizationWebsite = new HashSet<OrganizationWebsite>();
            OrganizationCalendar = new HashSet<OrganizationCalendar>();

            //K12School = new HashSet<K12School>();

            //RefAddressType = new HashSet<RefAddressType>();
            //RefCountry = new HashSet<RefCountry>();
            //RefEmailType = new HashSet<RefEmailType>();
            //RefGradeLevel = new HashSet<RefGradeLevel>();
            //RefGradeLevelType = new HashSet<RefGradeLevelType>();
            //RefOrganizationIdentifierType = new HashSet<RefOrganizationIdentifierType>();
            //RefOrganizationLocationType = new HashSet<RefOrganizationLocationType>();
            //RefOrganizationType = new HashSet<RefOrganizationType>();
            //RefSchoolLevel = new HashSet<RefSchoolLevel>();
            //RefSchoolType = new HashSet<RefSchoolType>();
            //RefSex = new HashSet<RefSex>();
            //RefState = new HashSet<RefState>();
            //RefTelephoneNumberType = new HashSet<RefTelephoneNumberType>();
            //Person = new HashSet<Person>();
            //PersonDetail = new HashSet<PersonDetail>();
            //PersonEmailAddress = new HashSet<PersonEmailAddress>();
            //PersonOtherName = new HashSet<PersonOtherName>();
            //PersonTelephone = new HashSet<PersonTelephone>();
            //PersonDegreeOrCertificate = new HashSet<PersonDegreeOrCertificate>();
            //PersonAddress = new HashSet<PersonAddress>();
        }
        [Key]
        public int OrganizationId { get; set; }
        [StringLength(36)]
        public string refId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationDetail> OrganizationDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationTelephone> OrganizationTelephone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationEmail> OrganizationEmail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationOperationalStatus> OrganizationOperationalStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationIdentifier> OrganizationIdentifier { get; set; }
        public virtual ICollection<OrganizationWebsite> OrganizationWebsite { get; set; }

        public virtual ICollection<OrganizationCalendar> OrganizationCalendar { get; set; }

        //public virtual ICollection<Person> Person { get; set; }
        //public virtual ICollection<PersonDetail> PersonDetail { get;set;}
        //public virtual ICollection<PersonEmailAddress> PersonEmailAddress { get; set; }
        //public virtual ICollection<PersonOtherName> PersonOtherName { get; set; }
        //public virtual ICollection<PersonTelephone> PersonTelephone { get; set; }
        //public virtual ICollection<PersonDegreeOrCertificate>PersonDegreeOrCertificate { get; set; }
        //public virtual ICollection<PersonAddress> PersonAddress { get; set; }



    }
}
