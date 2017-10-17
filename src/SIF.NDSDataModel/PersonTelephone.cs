namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.PersonTelephone")]
    public partial class PersonTelephone
    {
        public int PersonTelephoneId { get; set; }

        public int PersonId { get; set; }

        [StringLength(24)]
        public string TelephoneNumber { get; set; }

        public bool PrimaryTelephoneNumberIndicator { get; set; }

        public int? RefPersonTelephoneNumberTypeId { get; set; }

        public virtual Person Person { get; set; }
    }
}
