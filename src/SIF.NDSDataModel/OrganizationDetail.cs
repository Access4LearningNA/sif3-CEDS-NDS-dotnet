namespace SIF.NDSDataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("OrganizationDetail", Schema = "ODS")]
    public partial class OrganizationDetail
    {
        public int OrganizationDetailId { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        public int? RefOrganizationTypeId { get; set; }

        [StringLength(30)]
        public string ShortName { get; set; }

        public DateTime RecordStartDateTime { get; set; }

        public DateTime? RecordEndDateTime { get; set; }

       
    }
}
