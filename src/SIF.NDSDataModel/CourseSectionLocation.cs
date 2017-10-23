namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODS.CourseSectionLocation")]
    public partial class CourseSectionLocation
    {
        public int CourseSectionLocationId { get; set; }

        public int LocationId { get; set; }

        public int OrganizationId { get; set; }

        public int? RefInstructionLocationTypeId { get; set; }

        public virtual CourseSection CourseSection { get; set; }
    }
}
