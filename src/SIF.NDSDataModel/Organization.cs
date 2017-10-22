namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.Organization")]
    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            K12School = new HashSet<K12School>();
            OrganizationEmail = new HashSet<OrganizationEmail>();
            OrganizationDetail = new HashSet<OrganizationDetail>();
            OrganizationIdentifier = new HashSet<OrganizationIdentifier>();
            OrganizationOperationalStatus = new HashSet<OrganizationOperationalStatus>();
            OrganizationTelephone = new HashSet<OrganizationTelephone>();
            RefAddressType = new HashSet<RefAddressType>();
            RefCountry = new HashSet<RefCountry>();
            RefEmailType = new HashSet<RefEmailType>();
            RefGradeLevel = new HashSet<RefGradeLevel>();
            RefGradeLevelType = new HashSet<RefGradeLevelType>();
            RefOrganizationIdentifierType = new HashSet<RefOrganizationIdentifierType>();
            RefOrganizationLocationType = new HashSet<RefOrganizationLocationType>();
            RefOrganizationType = new HashSet<RefOrganizationType>();
            RefSchoolLevel = new HashSet<RefSchoolLevel>();
            RefSchoolType = new HashSet<RefSchoolType>();
            RefSex = new HashSet<RefSex>();
            RefState = new HashSet<RefState>();
            RefTelephoneNumberType = new HashSet<RefTelephoneNumberType>();
            Person = new HashSet<Person>();
            PersonDetail = new HashSet<PersonDetail>();
            PersonEmailAddress = new HashSet<PersonEmailAddress>();
            PersonOtherName = new HashSet<PersonOtherName>();
            PersonTelephone = new HashSet<PersonTelephone>();
            PersonDegreeOrCertificate = new HashSet<PersonDegreeOrCertificate>();
            PersonAddress = new HashSet<PersonAddress>();
        }

        public int OrganizationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<K12School> K12School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationEmail> OrganizationEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationDetail> OrganizationDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationIdentifier> OrganizationIdentifier { get; set; }
        public virtual ICollection<OrganizationLocation> OrganizationLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationOperationalStatus> OrganizationOperationalStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationTelephone> OrganizationTelephone { get; set; }

        public virtual OrganizationWebsite OrganizationWebsite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefAddressType> RefAddressType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefCountry> RefCountry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefEmailType> RefEmailType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefGradeLevel> RefGradeLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefGradeLevelType> RefGradeLevelType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefOrganizationIdentifierType> RefOrganizationIdentifierType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefOrganizationLocationType> RefOrganizationLocationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefOrganizationType> RefOrganizationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefSchoolLevel> RefSchoolLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefSchoolType> RefSchoolType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefSex> RefSex { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefState> RefState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefTelephoneNumberType> RefTelephoneNumberType { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PersonDetail> PersonDetail { get;set;}
        public virtual ICollection<PersonEmailAddress> PersonEmailAddress { get; set; }
        public virtual ICollection<PersonOtherName> PersonOtherName { get; set; }
        public virtual ICollection<PersonTelephone> PersonTelephone { get; set; }
        public virtual ICollection<PersonDegreeOrCertificate>PersonDegreeOrCertificate { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }



    }
}