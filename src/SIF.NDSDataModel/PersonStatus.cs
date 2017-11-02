namespace SIF.NDSDataModel
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonStatus", Schema = "ODS")]
    public partial class PersonStatus
    {
        public int PersonStatusId { get; set; }

        public int PersonId { get; set; }

        public int RefPersonStatusTypeId { get; set; }

        public bool StatusValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StatusStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StatusEndDate { get; set; }
    }
}
