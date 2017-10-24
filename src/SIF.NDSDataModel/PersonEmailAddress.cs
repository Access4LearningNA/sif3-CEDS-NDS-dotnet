namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonEmailAddress")]
    public partial class PersonEmailAddress
    {
        public int PersonEmailAddressId { get; set; }

        public int PersonId { get; set; }

        [StringLength(128)]
        public string EmailAddress { get; set; }

        public int? RefEmailTypeId { get; set; }

        public virtual Person Person { get; set; }

        public virtual RefEmailType RefEmailType { get; set; }
    }
}
