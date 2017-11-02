namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonLanguage", Schema = "ODS")]
    public partial class PersonLanguage
    {
        public int PersonLanguageId { get; set; }

        public int PersonId { get; set; }

        public int RefLanguageId { get; set; }

        public int RefLanguageUseTypeId { get; set; }
    }
}
