namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonRelationship", Schema = "ODS")]
    public partial class PersonRelationship
    {
        public int PersonRelationshipId { get; set; }

        public int PersonId { get; set; }

        public int RelatedPersonId { get; set; }

        public int? RefPersonRelationshipId { get; set; }

        public bool? CustodialRelationshipIndicator { get; set; }

        public bool? EmergencyContactInd { get; set; }

        public int? ContactPriorityNumber { get; set; }

        [StringLength(2000)]
        public string ContactRestrictions { get; set; }

        public bool? LivesWithIndicator { get; set; }

        public bool? PrimaryContactIndicator { get; set; }
    }
}
