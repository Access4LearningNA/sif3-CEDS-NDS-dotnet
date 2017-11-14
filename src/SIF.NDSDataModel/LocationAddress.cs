namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationAddress", Schema = "ODS")]
    public partial class LocationAddress
    {
        [Key]
        [ForeignKey("Location")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationId { get; set; }

        [StringLength(40)]
        public string StreetNumberAndName { get; set; }

        [StringLength(30)]
        public string ApartmentRoomOrSuiteNumber { get; set; }

        [StringLength(30)]
        public string BuildingSiteNumber { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        public int? RefStateId { get; set; }

        [StringLength(17)]
        public string PostalCode { get; set; }

        [StringLength(30)]
        public string CountyName { get; set; }

        public int? RefCountyId { get; set; }

        public int? RefCountryId { get; set; }

        [StringLength(20)]
        public string Latitude { get; set; }

        [StringLength(20)]
        public string Longitude { get; set; }

        public int? RefERSRuralUrbanContinuumCodeId { get; set; }

        public virtual Location Location { get; set; }

       
    }
}
