namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            PersonEmailAddress = new HashSet<PersonEmailAddress>();
            PersonDegreeOrCertificate = new HashSet<PersonDegreeOrCertificate>();
            PersonDemographicRace = new HashSet<PersonDemographicRace>();
            PersonDetail = new HashSet<PersonDetail>();
            PersonOtherName = new HashSet<PersonOtherName>();
            PersonTelephone = new HashSet<PersonTelephone>();
            PersonAddress = new HashSet<PersonAddress>();

        }

        public int PersonId { get; set; }

        public int? PersonMasterId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonEmailAddress> PersonEmailAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDegreeOrCertificate> PersonDegreeOrCertificate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDemographicRace> PersonDemographicRace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDetail> PersonDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonOtherName> PersonOtherName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTelephone> PersonTelephone { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
    }
}
