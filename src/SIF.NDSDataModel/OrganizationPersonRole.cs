namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizationPersonRole", Schema = "ODS")]
    public partial class OrganizationPersonRole
    {
        public OrganizationPersonRole()
        {
            K12StudentEnrollment = new HashSet<K12StudentEnrollment>();
            ELEnrollment= new HashSet<ELEnrollment>();
        }
        public int OrganizationPersonRoleId { get; set; }

        public int OrganizationId { get; set; }

        public int PersonId { get; set; }

        public int RoleId { get; set; }

        public DateTime? EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }
        [StringLength(36)]
        public string refId { get; set; }
        public virtual ICollection<K12StudentEnrollment> K12StudentEnrollment { get; set; }
        public virtual ICollection<ELEnrollment> ELEnrollment { get; set; }
    }
}
