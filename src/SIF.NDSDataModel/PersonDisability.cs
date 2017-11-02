namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDisability", Schema = "ODS")]
    public partial class PersonDisability
    {
        public int PersonId { get; set; }

        public int? PrimaryDisabilityTypeId { get; set; }

        public bool? DisabilityStatus { get; set; }

        public int? RefAccommodationsNeededTypeId { get; set; }

        public int? RefDisabilityConditionTypeId { get; set; }

        public int? RefDisabilityDeterminationSourceTypeId { get; set; }

        public int? RefDisabilityConditionStatusCodeId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public int PersonDisabilityId { get; set; }
    }
}
