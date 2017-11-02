namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonBirthplace", Schema = "ODS")]
    public partial class PersonBirthplace
    {
        [Key]
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        public int? RefStateId { get; set; }

        public int? RefCountryId { get; set; }
        public virtual Person Person { get; set; }
    }
}
