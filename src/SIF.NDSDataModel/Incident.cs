namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Incident", Schema = "ODS")]
    public partial class Incident
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Incident()
        {
            K12StudentDiscipline = new HashSet<K12StudentDiscipline>();
        }

        public int IncidentId { get; set; }

        [StringLength(40)]
        public string IncidentIdentifier { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IncidentDate { get; set; }

        public TimeSpan? IncidentTime { get; set; }

        public int? RefIncidentTimeDescriptionCodeId { get; set; }

        public string IncidentDescription { get; set; }

        public int? RefIncidentBehaviorId { get; set; }

        public int? RefIncidentBehaviorSecondaryId { get; set; }

        public int? RefIncidentInjuryTypeId { get; set; }

        public int? RefWeaponTypeId { get; set; }

        [StringLength(30)]
        public string IncidentCost { get; set; }

        public int? OrganizationPersonRoleId { get; set; }

        public int? IncidentReporterId { get; set; }

        public int? RefIncidentReporterTypeId { get; set; }

        public int? RefIncidentLocationId { get; set; }

        public int? RefFirearmTypeId { get; set; }

        [StringLength(100)]
        public string RegulationViolatedDescription { get; set; }

        public bool? RelatedToDisabilityManifestationInd { get; set; }

        public bool? ReportedToLawEnforcementInd { get; set; }

        public int? RefIncidentMultipleOffenseTypeId { get; set; }

        public int? RefIncidentPerpetratorInjuryTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<K12StudentDiscipline> K12StudentDiscipline { get; set; }
    }
}
