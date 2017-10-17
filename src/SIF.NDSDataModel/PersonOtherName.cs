namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonOtherName")]
    public partial class PersonOtherName
    {
        public int PersonOtherNameId { get; set; }

        public int PersonId { get; set; }

        public int? RefOtherNameTypeId { get; set; }

        [StringLength(40)]
        public string OtherName { get; set; }

        [StringLength(35)]
        public string FirstName { get; set; }

        [StringLength(35)]
        public string MiddleName { get; set; }

        [StringLength(35)]
        public string LastName { get; set; }

        public virtual Person Person { get; set; }
    }
}
