namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonIdentifier", Schema = "ODS")]
    public partial class PersonIdentifier
    {
        public int PersonIdentifierId { get; set; }

        public int PersonId { get; set; }

        [StringLength(40)]
        public string Identifier { get; set; }

        public int RefPersonIdentificationSystemId { get; set; }

        public int? RefPersonalInformationVerificationId { get; set; }
    }
}
