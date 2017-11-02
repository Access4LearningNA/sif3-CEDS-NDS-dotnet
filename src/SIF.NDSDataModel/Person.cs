namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person", Schema = "ODS")]
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
            PersonDisability = new HashSet<PersonDisability>();
            PersonIdentifier = new HashSet<PersonIdentifier>();
            PersonStatus = new HashSet<PersonStatus>();
            //PersonProgramParticipation = new HashSet<PersonProgramParticipation>();
            //ProgramParticipationSpecialEducation = new HashSet<ProgramParticipationSpecialEducation>();
            PersonLanguage = new HashSet<PersonLanguage>();
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
        public virtual ICollection<PersonDisability> PersonDisability { get; set; }
        public virtual ICollection<PersonIdentifier> PersonIdentifier { get; set; }
        public virtual ICollection<PersonStatus> PersonStatus { get; set; }
        //public virtual ICollection<PersonProgramParticipation> PersonProgramParticipation { get; set; }
        //public virtual ICollection<ProgramParticipationSpecialEducation> ProgramParticipationSpecialEducation { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguage { get; set; }
    }
    
}
