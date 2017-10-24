namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonBirthplace")]
    public partial class PersonBirthplace
    {
        public int PersonId { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        public int? RefStateId { get; set; }

        public int? RefCountryId { get; set; }
    }
}
