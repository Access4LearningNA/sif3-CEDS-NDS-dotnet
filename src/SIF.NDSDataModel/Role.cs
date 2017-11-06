namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role", Schema = "ODS")]
    public partial class Role
    {
        public int RoleId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? RefJurisdictionId { get; set; }
    }
}
