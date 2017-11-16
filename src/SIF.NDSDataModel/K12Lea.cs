namespace SIF.NDSDataModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("K12Lea", Schema = "ODS")]
    public partial class K12Lea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationId { get; set; }

        public int? RefLeaTypeId { get; set; }

        [StringLength(3)]
        public string SupervisoryUnionIdentificationNumber { get; set; }

        public int? RefLEAImprovementStatusId { get; set; }

        public int? RefPublicSchoolChoiceStatusId { get; set; }
    }
}
