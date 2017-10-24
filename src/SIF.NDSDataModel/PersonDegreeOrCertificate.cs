namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonDegreeOrCertificate")]
    public partial class PersonDegreeOrCertificate
    {
        public int PersonDegreeOrCertificateId { get; set; }

        public int PersonId { get; set; }

        [StringLength(45)]
        public string DegreeOrCertificateTitleOrSubject { get; set; }

        public int? RefDegreeOrCertificateTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AwardDate { get; set; }

        [StringLength(60)]
        public string NameOfInstitution { get; set; }

        public int? RefHigherEducationInstitutionAccreditationStatusId { get; set; }

        public int? RefEducationVerificationMethodId { get; set; }

        public virtual Person Person { get; set; }
    }
}
