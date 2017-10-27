namespace SIF.NDSDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonAddress", Schema = "ODS")]
    public partial class PersonAddress
    {
        public int PersonAddressId { get; set; }

        public int PersonId { get; set; }

        public int RefPersonLocationTypeId { get; set; }

        [StringLength(40)]
        public string StreetNumberAndName { get; set; }

        [StringLength(30)]
        public string ApartmentRoomOrSuiteNumber { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        public int? RefStateId { get; set; }

        [StringLength(17)]
        public string PostalCode { get; set; }

        [StringLength(30)]
        public string AddressCountyName { get; set; }

        public int? RefCountyId { get; set; }

        public int? RefCountryId { get; set; }

        [StringLength(20)]
        public string Latitude { get; set; }

        [StringLength(20)]
        public string Longitude { get; set; }

        public int? RefPersonalInformationVerificationId { get; set; }

        public virtual Person Person { get; set; }
    }
}
