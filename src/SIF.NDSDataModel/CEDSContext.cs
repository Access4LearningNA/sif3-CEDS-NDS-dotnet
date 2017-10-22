namespace SIF.NDSDataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CEDSContext : DbContext
    {
        public CEDSContext()
            : base("name=CEDSContext")
        {
        }

        public virtual DbSet<K12School> K12School { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationAddress> LocationAddress { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationDetail> OrganizationDetail { get; set; }
        public virtual DbSet<OrganizationEmail> OrganizationEmail { get; set; }
        public virtual DbSet<OrganizationIdentifier> OrganizationIdentifier { get; set; }
        public virtual DbSet<OrganizationOperationalStatus> OrganizationOperationalStatus { get; set; }
        public virtual DbSet<OrganizationTelephone> OrganizationTelephone { get; set; }
        public virtual DbSet<OrganizationWebsite> OrganizationWebsite { get; set; }
        public virtual DbSet<OrganizationLocation> OrganizationLocation { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonDegreeOrCertificate> PersonDegreeOrCertificate { get; set; }
        public virtual DbSet<PersonDemographicRace> PersonDemographicRace { get; set; }
        public virtual DbSet<PersonDetail> PersonDetail { get; set; }
        public virtual DbSet<PersonEmailAddress> PersonEmailAddress { get; set; }
        public virtual DbSet<PersonOtherName> PersonOtherName { get; set; }
        public virtual DbSet<PersonTelephone> PersonTelephone { get; set; }
        public virtual DbSet<RefAddressType> RefAddressType { get; set; }
        public virtual DbSet<RefCountry> RefCountry { get; set; }
        public virtual DbSet<RefEmailType> RefEmailType { get; set; }
        public virtual DbSet<RefGradeLevel> RefGradeLevel { get; set; }
        public virtual DbSet<RefGradeLevelType> RefGradeLevelType { get; set; }
        public virtual DbSet<RefOrganizationIdentifierType> RefOrganizationIdentifierType { get; set; }
        public virtual DbSet<RefOrganizationLocationType> RefOrganizationLocationType { get; set; }
        public virtual DbSet<RefOrganizationType> RefOrganizationType { get; set; }
        public virtual DbSet<RefSchoolLevel> RefSchoolLevel { get; set; }
        public virtual DbSet<RefSchoolType> RefSchoolType { get; set; }
        public virtual DbSet<RefSex> RefSex { get; set; }
        public virtual DbSet<RefState> RefState { get; set; }
        public virtual DbSet<RefTelephoneNumberType> RefTelephoneNumberType { get; set; }
        public virtual DbSet<SchoolAttributes> SchoolAttributes { get; set; }
        public virtual DbSet<SchoolAttributesCleanRecords> SchoolAttributesCleanRecords { get; set; }
        public virtual DbSet<SchoolAttributesErrorRecords> SchoolAttributesErrorRecords { get; set; }
        public virtual DbSet<K12StudentAcademicRecord> K12StudentAcademicRecord { get; set; }
        public virtual DbSet<K12StudentCohort> K12StudentCohort { get; set; }
        public virtual DbSet<PersonBirthplace> PersonBirthplace { get; set; }
        public virtual DbSet<PersonDisability> PersonDisability { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        public virtual DbSet<ProgramParticipationSpecialEducation> ProgramParticipationSpecialEducation { get; set; }
        public virtual DbSet<ProgramParticipationTitleI> ProgramParticipationTitleI { get; set; }
        public virtual DbSet<PsStudentCohort> PsStudentCohort { get; set; }
        public virtual DbSet<RefISO6393Language> RefISO6393Language { get; set; }
        public virtual DbSet<ELEnrollment> ELEnrollment { get; set; }
        public virtual DbSet<K12StudentEnrollment> K12StudentEnrollment { get; set; }
        public virtual DbSet<CourseSectionSchedule> CourseSectionSchedule { get; set; }
        public virtual DbSet<CteCourse> CteCourse { get; set; }
        public virtual DbSet<K12StaffAssignment> K12StaffAssignment { get; set; }
        public virtual DbSet<K12StudentCourseSection> K12StudentCourseSection { get; set; }
        public virtual DbSet<ProgramParticipationCte> ProgramParticipationCte { get; set; }
        public virtual DbSet<PsStudentSection> PsStudentSection { get; set; }
        public virtual DbSet<RoleAttendanceEvent> RoleAttendanceEvent { get; set; }
        public virtual DbSet<K12StudentCourseSectionMark> K12StudentCourseSectionMark { get; set; }
        public virtual DbSet<OrganizationCalendar> OrganizationCalendar { get; set; }
        public virtual DbSet<OrganizationCalendarEvent> OrganizationCalendarEvent { get; set; }
        public virtual DbSet<OrganizationCalendarSession> OrganizationCalendarSession { get; set; }
        public virtual DbSet<RoleAttendance> RoleAttendance { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasOptional(e => e.LocationAddress)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.K12School)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrganizationEmail)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrganizationDetail)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrganizationIdentifier)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
              .HasMany(e => e.OrganizationLocation)
              .WithRequired(e => e.Organization)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrganizationOperationalStatus)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrganizationTelephone)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasOptional(e => e.OrganizationWebsite)
                .WithRequired(e => e.Organization);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefAddressType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefCountry)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefEmailType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefGradeLevel)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefGradeLevelType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefOrganizationIdentifierType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefOrganizationLocationType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefOrganizationType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefSchoolLevel)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefSchoolType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefSex)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefState)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.RefTelephoneNumberType)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.RefJurisdictionId);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonEmailAddress)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonDegreeOrCertificate)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonDemographicRace)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonDetail)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonOtherName)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RefAddressType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefCountry>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefEmailType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefGradeLevel>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefGradeLevelType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefOrganizationIdentifierType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefOrganizationLocationType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefOrganizationType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefSchoolLevel>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefSchoolType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefSex>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefState>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RefState>()
                .HasMany(e => e.PersonDetail)
                .WithOptional(e => e.RefState)
                .HasForeignKey(e => e.RefStateOfResidenceId);

            modelBuilder.Entity<RefTelephoneNumberType>()
                .Property(e => e.SortOrder)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.emailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.emailTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.externalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.idTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.localIdIdvalue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.operationalStatusCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.phoneNumberExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.phoneNumberTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactAddressRole)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactBirthdate)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactBirthdateverification)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactcountryOfResidencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactSexus)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactElectronicIdValue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactEmailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactEmailTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactExternalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactExternalIdvalue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactLocalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactLocalIdValue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactFamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactFullname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactGivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactMiddlename)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactPreferredfamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactPreferredgivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactPrefix)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactOtherNameFamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactOtherNameFullname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactOtherNameGivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactOtherNameMiddlename)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactOtherNamePreferredfamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactOtherNamePreferredgivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactphoneNumberExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactphoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolContactphoneNumberTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolFocus)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolName)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolSector)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.schoolURL)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributes>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.ErrorReason)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.emailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.emailTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.externalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.idTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.localIdIdvalue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.operationalStatusCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.phoneNumberExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.phoneNumberTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactAddressRole)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactBirthdate)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactBirthdateverification)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactcountryOfResidencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactSexus)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactElectronicIdValue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactEmailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactEmailTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactExternalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactExternalIdvalue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactLocalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactLocalIdValue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactFamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactFullname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactGivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactMiddlename)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactPreferredfamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactPreferredgivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactPrefix)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactOtherNameFamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactOtherNameFullname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactOtherNameGivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactOtherNameMiddlename)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactOtherNamePreferredfamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactOtherNamePreferredgivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactphoneNumberExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactphoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolContactphoneNumberTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolFocus)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolName)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolSector)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.schoolURL)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesCleanRecords>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.ErrorReason)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.emailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.emailTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.externalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.idTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.localIdIdvalue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.operationalStatusCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.phoneNumberExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.phoneNumberTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactAddressRole)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactBirthdate)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactBirthdateverification)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactcountryOfResidencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactSexus)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactElectronicIdValue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactEmailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactEmailTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactExternalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactExternalIdvalue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactLocalIdTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactLocalIdValue)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactFamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactFullname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactGivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactMiddlename)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactPreferredfamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactPreferredgivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactPrefix)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactOtherNameFamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactOtherNameFullname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactOtherNameGivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactOtherNameMiddlename)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactOtherNamePreferredfamilyname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactOtherNamePreferredgivenname)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactphoneNumberExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactphoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolContactphoneNumberTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolFocus)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolName)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolSector)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.schoolURL)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolAttributesErrorRecords>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
            modelBuilder.Entity<Person>()
               .HasMany(e => e.PersonAddress)
               .WithRequired(e => e.Person)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<K12StudentAcademicRecord>()
                .Property(e => e.CreditsAttemptedCumulative)
                .HasPrecision(9, 2);

            modelBuilder.Entity<K12StudentAcademicRecord>()
                .Property(e => e.CreditsEarnedCumulative)
                .HasPrecision(9, 2);

            modelBuilder.Entity<K12StudentAcademicRecord>()
                .Property(e => e.GradePointsEarnedCumulative)
                .HasPrecision(9, 2);

            modelBuilder.Entity<K12StudentAcademicRecord>()
                .Property(e => e.GradePointAverageCumulative)
                .HasPrecision(9, 4);

            modelBuilder.Entity<K12StudentAcademicRecord>()
                .Property(e => e.ProjectedGraduationDate)
                .IsFixedLength();

            modelBuilder.Entity<K12StudentAcademicRecord>()
                .Property(e => e.DiplomaOrCredentialAwardDate)
                .IsFixedLength();

            modelBuilder.Entity<K12StudentCohort>()
                .Property(e => e.CohortYear)
                .IsFixedLength();

            modelBuilder.Entity<K12StudentCohort>()
                .Property(e => e.CohortGraduationYear)
                .IsFixedLength();

            modelBuilder.Entity<K12StudentCohort>()
                .Property(e => e.GraduationRateSurveyCohortYear)
                .IsFixedLength();

            modelBuilder.Entity<ProgramParticipationSpecialEducation>()
                .Property(e => e.SpecialEducationFTE)
                .HasPrecision(5, 4);

            modelBuilder.Entity<PsStudentCohort>()
                .Property(e => e.CohortGraduationYear)
                .IsFixedLength();

            modelBuilder.Entity<RefISO6393Language>()
                .Property(e => e.SortOrder)
                .HasPrecision(6, 2);

            modelBuilder.Entity<ELEnrollment>()
                .Property(e => e.NumberOfDaysInAttendance)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CteCourse>()
                .Property(e => e.AvailableCarnegieUnitCredit)
                .HasPrecision(9, 2);

            modelBuilder.Entity<CteCourse>()
                .Property(e => e.SCEDCourseCode)
                .IsFixedLength();

            modelBuilder.Entity<K12StaffAssignment>()
                .Property(e => e.FullTimeEquivalency)
                .HasPrecision(5, 4);

            modelBuilder.Entity<K12StaffAssignment>()
                .Property(e => e.ContributionPercentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<K12StudentCourseSection>()
                .Property(e => e.NumberOfCreditsAttempted)
                .HasPrecision(9, 2);

            modelBuilder.Entity<K12StudentCourseSection>()
                .Property(e => e.NumberOfCreditsEarned)
                .HasPrecision(9, 2);

            modelBuilder.Entity<PsStudentSection>()
                .Property(e => e.NumberOfCreditsEarned)
                .HasPrecision(9, 2);

            modelBuilder.Entity<PsStudentSection>()
                .Property(e => e.QualityPointsEarned)
                .HasPrecision(9, 2);

            modelBuilder.Entity<OrganizationCalendar>()
                .Property(e => e.CalendarYear)
                .IsFixedLength();

            modelBuilder.Entity<OrganizationCalendarSession>()
                .Property(e => e.InstructionalMinutes)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RoleAttendance>()
                .Property(e => e.NumberOfDaysInAttendance)
                .HasPrecision(9, 2);

            modelBuilder.Entity<RoleAttendance>()
                .Property(e => e.NumberOfDaysAbsent)
                .HasPrecision(9, 2);

            modelBuilder.Entity<RoleAttendance>()
                .Property(e => e.AttendanceRate)
                .HasPrecision(5, 4);
        }
    }
}
