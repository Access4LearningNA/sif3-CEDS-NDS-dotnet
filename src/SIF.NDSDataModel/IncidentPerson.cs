namespace SIF.NDSDataModel
{
   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("IncidentPerson", Schema = "ODS")]
    public partial class IncidentPerson
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Incident")]
        public int IncidentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        [StringLength(40)]
        public string Identifier { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("RefIncidentPersonRoleType")]
        public int RefIncidentPersonRoleTypeId { get; set; }

        public int? RefIncidentPersonTypeId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Incident Incident { get; set; }
        public virtual RefIncidentPersonRoleType RefIncidentPersonRoleType { get; set; }

    }
}
