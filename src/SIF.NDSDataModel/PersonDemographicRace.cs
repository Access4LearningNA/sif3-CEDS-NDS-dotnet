namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonDemographicRace")]
    public partial class PersonDemographicRace
    {
        public int PersonDemographicRaceId { get; set; }

        public int PersonId { get; set; }

        public int RefRaceId { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

        public virtual Person Person { get; set; }
    }
}
